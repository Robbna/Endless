using UnityEngine.UI;
using UnityEngine;

public class mYouDieHUD : MonoBehaviour
{
    [SerializeField] private Text currentScore;
    [SerializeField] private Text maxScore;

    private void Update()
    {
        currentScore.text = "Current score: " + Player.currentScore.ToString();
        maxScore.text = "MAX SCORE: " + Player.score.ToString();
    }

}
