using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;

    [SerializeField] private float speed;
    private void Update()
    {
        if (IARayCast.isLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (IARayCast.isRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
}
