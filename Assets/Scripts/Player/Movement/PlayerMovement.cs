using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    // IMPORTANT variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the speed that the player will have.")]
    [SerializeField] private float playerSpeed;
    [Tooltip("This variable represent the jump force that the player will have.")]
    [SerializeField] private float playerJumpForce;
    // Private variables.
    private Rigidbody2D rgb;
    private bool canJump;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        // Variable to store the input data from the player [-1, 1].
        float dirX = Input.GetAxis("Horizontal");
        // Player movement based on the input data.
        transform.Translate(new Vector2(dirX, 0.0f) * playerSpeed * Time.deltaTime);

        canJump = mCheckGround.checkGround(gameObject.transform, 1f);

        if (canJump)
        {
            Jump();
        }





    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rgb.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        }
    }


}
