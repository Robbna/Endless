using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARayCast : MonoBehaviour
{
    // IMPORTANT variables.
    [Header("[!] IMPORTANT VARIABLES")]
    [SerializeField] private GameObject objectToDetect;
    // MISC variables.
    [Header("[?] Public variables")]
    [SerializeField] public float rayDistance;
    // Private variables.
    private RaycastHit2D hitLeft, hitRight;
    public static bool isLeft, isRight;

    private void Update()
    {
        // Shot ray to the left and right side.
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance);
        // !TODO : Por alguna razón, si guardo lo siguiente en dos métodos distintos ('checkLeft', 'checkRight') no funciona la lógica.
        // --------------------< CHECK LEFT >--------------------
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag.Equals(objectToDetect.gameObject.tag))
            {
                isLeft = true;
            }
        }
        else
        {
            isLeft = false;
        }
        // --------------------< CHECK RIGHT >--------------------
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag.Equals(objectToDetect.gameObject.tag))
            {
                isRight = true;
            }
        }
        else
        {
            isRight = false;
        }

        // DEBUG >>>>>
        Debug.DrawRay(transform.position, Vector2.left * rayDistance, Color.green);
        Debug.DrawRay(transform.position, Vector2.right * rayDistance, Color.green);

    }
}


