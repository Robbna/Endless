using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int score;
    public static int currentScore;
    public static bool isAlive;

    [SerializeField] private Text scoreText;

    private void Start()
    {
        DBAuthManager.getUserScore();
        isAlive = true;
        currentScore = 0;
    }

    public static void playerDeath()
    {
        isAlive = false;
        if (currentScore > score)
        {
            score = currentScore;
            DBAuthManager.saveScore();
        }
    }

}
