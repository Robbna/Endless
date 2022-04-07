using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCheckGround : MonoBehaviour
{
    public static bool checkGround(Transform gameObject, float jumpDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.position, Vector2.down, jumpDistance);
        Debug.DrawRay(gameObject.position, Vector2.down * jumpDistance, Color.green);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
