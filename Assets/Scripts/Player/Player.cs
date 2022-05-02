using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int score;

    [SerializeField] private Text scoreText;

    private void Start() {
        DBAuthManager.getUserScore();
    }

    private void Update()
    {

        scoreText.text = score.ToString();

    }

}
