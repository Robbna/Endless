using UnityEngine;
using UnityEngine.SceneManagement;

public class mHUD : MonoBehaviour
{
    [SerializeField] private GameObject canvas_Login;
    [SerializeField] private GameObject canvas_Register;

    private void Start()
    {
        canvas_Login.SetActive(true);
        canvas_Register.SetActive(false);

    }

    public void viewRegister()
    {
        canvas_Register.SetActive(true);
        canvas_Login.SetActive(false);
    }

    public void viewLogin()
    {
        canvas_Login.SetActive(true);
        canvas_Register.SetActive(false);
    }

    public void loadScene(string sceneName)
    {
        if (DBAuthManager.isUserIn)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
