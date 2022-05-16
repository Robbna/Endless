using UnityEngine;
// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(IADistance_movement))]
public class IADistance : MonoBehaviour
{
    // IMPORTANT variables.
    [SerializeField] private Transform objectToDetect;
    // MISC variables.
    [SerializeField] public float minDistance;
    // Private variables.
    private float currentDistance;
    // Public variables.
    [HideInInspector] public bool isNear;

    private void Update()
    {
        currentDistance = Vector2.Distance(transform.position, objectToDetect.position);

        if (currentDistance <= minDistance)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }

    }
}
