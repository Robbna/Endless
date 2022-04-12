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
    private void Start()
    {
        distanceIA = GetComponent<IADistance>();
        detectDirectionM = GetComponent<mDetectDirection>();
    }


    void Update()
    {
        if (distanceIA.isNear && detectDirectionM.dirLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (distanceIA.isNear && detectDirectionM.dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
