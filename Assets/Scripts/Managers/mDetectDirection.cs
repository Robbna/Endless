using UnityEngine;

public class mDetectDirection : MonoBehaviour
{
    [SerializeField] private Transform objectToDetect;
    [HideInInspector] public bool dirLeft, dirRight;

    private void Update()
    {

        if (transform.position.x < objectToDetect.position.x)
        {
            dirRight = true;
            dirLeft = false;
        }
        else
        {
            dirLeft = true;
            dirRight = false;
        }
    }
}
