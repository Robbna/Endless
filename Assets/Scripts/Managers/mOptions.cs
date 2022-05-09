using UnityEngine;
using UnityEngine.SceneManagement;

public class mOptions : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainHud;

    [SerializeField] private GameObject youDiePanel;

    private Scene scene;

    private void Start()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        youDiePanel.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainHud.SetActive(false);
            optionsPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if(!Player.isAlive){
            mainHud.SetActive(false);
            youDiePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void backGame()
    {
        mainHud.SetActive(true);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;


    }

    public void restartGame()
    {
        SceneManager.LoadScene(scene.name);
    }

    public void backMenu()
    {

        DBAuthManager.saveScore();
        SceneManager.LoadScene("MainMenu");

    }

}
