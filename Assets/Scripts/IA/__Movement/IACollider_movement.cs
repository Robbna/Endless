using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [!] COMPONENTS REQUIRED.
[RequireComponent(typeof(mDetectDirection))]
public class IACollider_movement : MonoBehaviour
{
    // MISC variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the speed that the object will have.")]
    [SerializeField] private float speed;
    private IAColliderZone colliderZoneIA;
    private mDetectDirection detectDirectionM;

    private void Start()
    {
        colliderZoneIA = GetComponent<IAColliderZone>();
        detectDirectionM = GetComponent<mDetectDirection>();
    }
    void Update()
    {
        if (colliderZoneIA.isNear && detectDirectionM.dirLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (colliderZoneIA.isNear && detectDirectionM.dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
