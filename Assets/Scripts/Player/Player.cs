using UnityEngine;

public class Player : MonoBehaviour
{
    public static int score;
    public static int currentScore = 0;
    public static bool isAlive;
    private static AudioSource audioCoin;

    private void Start()
    {
        audioCoin = GetComponent<AudioSource>();
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

    public static void soundCoin(){
        audioCoin.Play();
    }

}
