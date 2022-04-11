using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [!] COMPONENTS REQUIRED.
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(IACollider_movement))]

public class IAColliderZone : MonoBehaviour
{
    // Public variables.
    [HideInInspector] public bool isNear;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isNear = false;
        }
    }
}
