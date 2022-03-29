using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAColliderZone : MonoBehaviour
{
    // Private variables.
    private RaycastHit2D hitLeft, hitRight;
    // Static variables.
    public static bool isNear;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isNear = true;
            print("PLAYER");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isNear = false;
            print("PLAYER");
        }
    }
}
