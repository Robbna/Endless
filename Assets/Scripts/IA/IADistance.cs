using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Static variables.
    public static bool isNear;

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
