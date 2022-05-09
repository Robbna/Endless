using UnityEngine;

// [!] COMPONENTS REQUIRED.
[RequireComponent(typeof(mDetectDirection), typeof(IADistance))]
public class IADistance_movement : MonoBehaviour
{
    // MISC variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the speed that the object will have.")]
    [SerializeField] private float speed;
    [SerializeField] private IADistance distanceIA;
    [SerializeField] private mDetectDirection detectDirectionM;
    [SerializeField] private Transform playerTransform;

    private SpriteRenderer spr;
    private void Start()
    {
        distanceIA = GetComponent<IADistance>();
        detectDirectionM = GetComponent<mDetectDirection>();
        spr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        if (distanceIA.isNear && detectDirectionM.dirLeft)
        {
            spr.flipX = false;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        if (distanceIA.isNear && detectDirectionM.dirRight)
        {
            spr.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }
}
