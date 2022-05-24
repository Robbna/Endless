using UnityEngine;
using UnityEngine.UI;

public class mOptions : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainHud;
    [SerializeField] private GameObject controlHud;
    [SerializeField] private GameObject suggestionlPanel;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text maxScore;

    [SerializeField] private GameObject youDiePanel;

    private void Start()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        youDiePanel.SetActive(false);
        suggestionlPanel.SetActive(false);
        controlHud.SetActive(true);
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

    public void openSuggestion()
    {
        optionsPanel.SetActive(false);
        suggestionlPanel.SetActive(true);
    }
    public void closeSuggestion()
    {
        suggestionlPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void openMenu()
    {
        mainHud.SetActive(false);
        optionsPanel.SetActive(true);
        controlHud.SetActive(false);
        Time.timeScale = 0f;
    }

    public void backGame()
    {
        mainHud.SetActive(true);
        controlHud.SetActive(true);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;


    }

    public void restartGame()
    {
        LevelUtils.loadLevel("Level1");
    }

    public void backMenu()
    {

        DBAuthManager.saveScore();
        LevelUtils.loadLevel("MainMenu");

    }

}
