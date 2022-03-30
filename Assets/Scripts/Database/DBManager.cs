using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    [SerializeField] private InputField nameField, emailField, passwdField;
    // private string userID;
    private DatabaseReference dbReference;

    void Start()
    {
        // Unique ID per user.
        // userID = SystemInfo.deviceUniqueIdentifier;
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void addUser()
    {
        // Create new User with parameters.
        User newUser = new User(nameField.text, emailField.text, passwdField.text);
        // JSONfy the newUser data.
        string json = JsonUtility.ToJson(newUser);
        // Add to the DataBase the newUser data.
        dbReference.Child("users").Push().SetRawJsonValueAsync(json);
    }
}
