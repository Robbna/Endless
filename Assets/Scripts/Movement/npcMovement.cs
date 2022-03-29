using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    // MISC variables.
    [Header("[?] Public variables")]
    [SerializeField] private float speed;

    private void Update()
    {
        // --------------------< IF 'RAYCAST IA' IS ENABLED >--------------------
        if (IARayCast.isLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (IARayCast.isRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        // --------------------< IF 'COLLIDER IA' IS ENABLED >--------------------
        if (IAColliderZone.isNear && mDetectDirection.dirLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (IAColliderZone.isNear && mDetectDirection.dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
}
