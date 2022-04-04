using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;

public class DBAuthManager : MonoBehaviour
{
    [SerializeField] private InputField nickFieldRegister, emailFieldRegister, passwdFieldRegister;
    [SerializeField] private InputField emailFieldLogin, passwdFieldLogin;
    [SerializeField] private Text testText;
    //[SerializeField] private mPopUp popUp;
    private FirebaseAuth auth;
    private FirebaseUser user;
    private DatabaseReference mDatabaseRef;

    void Start()
    {
        // AUTH database reference.
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        // REALTIME database reference.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

    }

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
            //popUp.showMessage("User created successfully!", 3);


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

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    private void addUser(string name, string email)
    {
        // Create new user.
        User newUser = new User(name, email, 0);
        // JSONfy newUser.
        string json = JsonUtility.ToJson(newUser);
        // Push newUser to RealTime database.
        mDatabaseRef.Child("users").Push().SetRawJsonValueAsync(json);
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
                        var score = childSnapshot.Child("email").Value.ToString();
                        testText.text = score.ToString();
                        Debug.Log(name.ToString());
                    }
                }
            };
    }
}
