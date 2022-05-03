using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;

public class DBAuthManager : MonoBehaviour
{
    [Header("[!] NOT IMPORTANT VARIABLES")]
    [Tooltip("This variables represents the MainMenu textBoxes for register.")]
    [SerializeField] private InputField nickFieldRegister, emailFieldRegister, passwdFieldRegister;
    [Tooltip("This variables represents the MainMenu textBoxes for login.")]
    [SerializeField] private InputField emailFieldLogin, passwdFieldLogin;
    [SerializeField] private Text userState;
    [Tooltip("This variables represents the StartGame button.")]
    [SerializeField] private GameObject startGameButton;
    public static FirebaseAuth auth;
    public static FirebaseUser user;
    public static DatabaseReference mDatabaseRef;
    public static bool isUserIn;


    private void Start()
    {

        // AUTH database reference.
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        // REALTIME database reference.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        isUserIn = false;
    }

    private void addUser(string name, string email)
    {
        // Create new user.
        User newUser = new User(name, email, 0);
        // JSONfy newUser.
        string json = JsonUtility.ToJson(newUser);
        // Push newUser to RealTime database.
        mDatabaseRef.Child("users").Push().SetRawJsonValueAsync(json);
        //pushKey = mDatabaseRef.Child("users").Push().Key;
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
                // Show message
                mPopUp.inst.showMessage(task.Exception.ToString());
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                // Show message
                mPopUp.inst.showMessage(task.Exception.ToString());
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                // Firebase user has been created.
                FirebaseUser newUser = task.Result;
                // Push user to Realtime Database.
                addUser(nickFieldRegister.text, emailFieldRegister.text);
                isUserIn = true;
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
            if (task.IsCompleted)
            {
                FirebaseUser newUser = task.Result;
                isUserIn = true;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                getUserScore();

            }

        });
    }

    public static void getUserScore() // https://www.codegrepper.com/code-examples/go/firebase+where+unity+query
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
                        mDatabaseRef.Child("users").Child(childSnapshot.Key).Child("score").SetValueAsync(Player.score);

                    }
                }
            };
    }
}
