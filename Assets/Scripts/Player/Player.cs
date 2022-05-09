using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int score;
    public static int currentScore;

    [SerializeField] private Text scoreText;

    private void Start()
    {
        DBAuthManager.getUserScore();
        currentScore = 0;
    }

    public static void playerDeath()
    {
        if (currentScore > score)
        {
            score = currentScore;
            DBAuthManager.saveScore();
        }
    }

}
