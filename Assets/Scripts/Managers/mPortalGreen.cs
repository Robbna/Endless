using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mPortalGreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float forceToDropPlayer;
    [SerializeField] private string levelToLoad;
    [SerializeField] private bool isPlayerSpawn;

    private void Start()
    {
        if (isPlayerSpawn)
        {
            player.transform.position = gameObject.transform.position;
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToDropPlayer, ForceMode2D.Impulse);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToLoad);
        }


    }
}
