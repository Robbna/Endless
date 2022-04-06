using UnityEngine.UI;
using UnityEngine;

public class mHUD : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Player player;

    private void Update() {
        scoreText.text = player.score.ToString();
    }
}
