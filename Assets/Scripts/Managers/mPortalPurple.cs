using UnityEngine;

public class mPortalPurple : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform secondPortal;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (secondPortal != null)
            {
                player.position = secondPortal.position;
            }


        }
    }

}
