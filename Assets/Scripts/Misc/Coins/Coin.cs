using UnityEngine;

// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.score++;
            print(Player.score);
            Destroy(gameObject);
        }
    }
}
