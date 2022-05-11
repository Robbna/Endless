using UnityEngine;

public class Player : MonoBehaviour
{
    public static int score;
    public static int currentScore = 0;
    public static bool isAlive;

    private void Start()
    {
        DBAuthManager.getUserScore();
        isAlive = true;
        if ("Level1".Equals(LevelUtils.getCurrentScene().name))
        {
            currentScore = 0;
        }
    }

    public static void playerSave()
    {
        isAlive = false;
        if (currentScore > score)
        {
            score = currentScore;
            DBAuthManager.saveScore();
        }
    }

}
