using UnityEngine.UI;
using UnityEngine;

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
    // [SerializeField] private Text scoreText;
    // [SerializeField] private Player player;

    // private void Update() {
    //     scoreText.text = player.score.ToString();
    // }
}
