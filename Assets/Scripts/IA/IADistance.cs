using UnityEngine;
// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(IADistance_movement))]
public class IADistance : MonoBehaviour
{
    // IMPORTANT variables.
    [Header("[!] IMPORTANT VARIABLES")]
    [Tooltip("This variable represent the object to detect and his 'Transform' component.")]
    [SerializeField] private Transform objectToDetect;
    // MISC variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the minimal distance to detect the object.")]
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
