using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;

public class DBAuthManager : MonoBehaviour
{
    [SerializeField] private InputField nickField, emailField, passwdField;
    private FirebaseAuth auth;
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
        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwdField.text).ContinueWith(task =>
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

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            // Push user to Realtime Database.
            addUser(nickField.text, emailField.text);
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
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
}

