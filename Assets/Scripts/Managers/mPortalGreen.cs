using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mPortalGreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float forceToDropPlayer;
    [SerializeField] private string levelToLoad;
    [SerializeField] private float secondsToTP;

    private void Start()
    {
        player.transform.position = gameObject.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToDropPlayer, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Player.score == 30)
        {
            other.gameObject.SetActive(false);
            StartCoroutine(loadScene(levelToLoad, secondsToTP));
        }
    }

    private IEnumerator loadScene(string levelName, float time)
    {

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(levelName);
    }
    private IEnumerator hidePortal(float time)
    {

        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
