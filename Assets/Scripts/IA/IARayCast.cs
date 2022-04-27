using UnityEngine;

// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(IARayCast_movement))]
[RequireComponent(typeof(IARayCast_movement))]
public class IARayCast : MonoBehaviour
{
    // IMPORTANT variables.
    [Header("[!] IMPORTANT VARIABLES")]
    [Tooltip("This variable represent the object to detect.")]
    [SerializeField] private GameObject objectToDetect;
    // MISC variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the ray distance.")]
    [SerializeField] public float rayDistance;
    // Private variables.
    private RaycastHit2D hitLeft, hitRight;
    // Public variables.
    [HideInInspector] public bool isLeft, isRight;

    private void Update()
    {
        // Shot ray to the left and right side.
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance);
        // !TODO : Por alguna razón, si guardo el siguiente código en dos métodos distintos ('checkLeft', 'checkRight') no funciona la lógica.
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


