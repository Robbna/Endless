using UnityEngine;
using UnityEngine.UI;

public class mOptions : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainHud;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text maxScore;

    [SerializeField] private GameObject youDiePanel;

    private void Start()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        youDiePanel.SetActive(false);
    }

    private void Update()
    {
        currentScore.text = "Current score: " + Player.currentScore.ToString();
        maxScore.text = "Max score: " + Player.score.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            mainHud.SetActive(false);
            optionsPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (!Player.isAlive)
        {
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
        LevelUtils.loadLevel(LevelUtils.getCurrentScene().name);
    }

    public void backMenu()
    {

        DBAuthManager.saveScore();
        LevelUtils.loadLevel("MainMenu");

    }

}
