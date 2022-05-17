using UnityEngine;

// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(IARayCast_movement))]
[RequireComponent(typeof(IARayCast_movement))]
public class IARayCast : MonoBehaviour
{
    [SerializeField] private GameObject objectToDetect;
    [SerializeField] public float rayDistance;
    private RaycastHit2D hitLeft, hitRight;
    [HideInInspector] public bool isLeft, isRight;

    private void Update()
    {
        // Shot ray to the left and right side.
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance);


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
    }
}


