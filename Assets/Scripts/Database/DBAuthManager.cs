using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;

public class DBAuthManager : MonoBehaviour
{
    [SerializeField] private InputField nickFieldRegister, emailFieldRegister, passwdFieldRegister;
    [SerializeField] private InputField emailFieldLogin, passwdFieldLogin;
    [SerializeField] private Player player;
    //[SerializeField] private mPopUp popUp;
    private static FirebaseAuth auth;
    private static FirebaseUser user;
    private static DatabaseReference mDatabaseRef;
    private static string pushKey;


    private void Start()
    {
        // AUTH database reference.
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        // REALTIME database reference.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void addUser(string name, string email)
    {
        // Create new user.
        User newUser = new User(name, email, 0);
        // JSONfy newUser.
        string json = JsonUtility.ToJson(newUser);
        // Push newUser to RealTime database.
        mDatabaseRef.Child("users").Push().SetRawJsonValueAsync(json);
        pushKey = mDatabaseRef.Child("users").Push().Key;
    }

    /*
    PUBLIC METHODS
    */
    public void registerUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailFieldRegister.text, passwdFieldRegister.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                // Firebase user has been created.
                FirebaseUser newUser = task.Result;
                // Push user to Realtime Database.
                addUser(nickFieldRegister.text, emailFieldRegister.text);
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            }

        });
    }

    public void loginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(emailFieldLogin.text, passwdFieldLogin.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            getUserScore();
        });
    }

    public void getUserScore() // https://www.codegrepper.com/code-examples/go/firebase+where+unity+query
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("users").OrderByChild("email").EqualTo(auth.CurrentUser.Email)
            .ValueChanged += (object sender2, ValueChangedEventArgs e2) =>
            {
                if (e2.DatabaseError != null)
                {
                    Debug.LogError(e2.DatabaseError.Message);
                }
                if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
                {
                    foreach (var childSnapshot in e2.Snapshot.Children)
                    {
                        var score = childSnapshot.Child("score").Value;
                        //player.score = Convert.ToInt32(score.ToString());
                        Player.score = Convert.ToInt32(score.ToString());
                    }
                }
            };
    }

    public void saveScore()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("users").OrderByChild("email").EqualTo(auth.CurrentUser.Email)
            .ValueChanged += (object sender2, ValueChangedEventArgs e2) =>
            {
                if (e2.DatabaseError != null)
                {
                    Debug.LogError(e2.DatabaseError.Message);
                }
                if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
                {
                    foreach (var childSnapshot in e2.Snapshot.Children)
                    {
                        var score = childSnapshot.Child("score").Value.ToString();
                        // mDatabaseRef.Child("users").Child(childSnapshot.Key).Child("score").SetValueAsync(player.score);
                        mDatabaseRef.Child("users").Child(childSnapshot.Key).Child("score").SetValueAsync(Player.score);

                    }
                }
            };



    }
}
