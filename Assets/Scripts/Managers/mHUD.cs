using UnityEngine;
using UnityEngine.UI;

public class mHUD : MonoBehaviour
{
    [SerializeField] private GameObject canvas_Login;
    [SerializeField] private GameObject canvas_Register;
    [SerializeField] private GameObject canvas_StartGame;
    [SerializeField] private Text canvas_State;

    private void Start()
    {
        canvas_State.text = "You are not loggued!";
        canvas_State.color = Color.red;
        canvas_Login.SetActive(true);
        canvas_Register.SetActive(false);
        canvas_StartGame.SetActive(false);

    }

    private void Update()
    {
        if (DBAuthManager.isUserIn)
        {
            canvas_State.text = "START GAME!";
            canvas_State.color = Color.green;
            canvas_StartGame.SetActive(true);
            canvas_Login.SetActive(false);
            canvas_Register.SetActive(false);
        }
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
            LevelUtils.loadLevel(sceneName);
        }

    }
}
