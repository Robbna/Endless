using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IADistance : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private Vector3 pPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pPosition = player.position;

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
