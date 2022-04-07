using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    // IMPORTANT variables.
    [Header("[?] Public variables")]
    [Tooltip("This variable represent the speed that the player will have.")]
    [SerializeField] private float playerSpeed;
    [Tooltip("This variable represent the jump force that the player will have.")]
    [SerializeField] private float playerJumpForce;
    [Tooltip("This variable represent the jump altitude that the player will have.")]
    [SerializeField] private float playerJumpAltitude;
    // Private variables.
    private Rigidbody2D rgb;
    private SpriteRenderer spr;
    private Animator anim;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        // Variable to store the input data from the player [-1, 1].
        float dirX = Input.GetAxis("Horizontal");

        if (dirX == 0)
        {
            anim.SetBool("isRunning", false);
        }

        if (dirX > 0)
        {
            spr.flipX = false;
            anim.SetBool("isRunning", true);

        }
        if (dirX < 0)
        {
            spr.flipX = true;
            anim.SetBool("isRunning", true);

        }


        // Player movement based on the input data.
        transform.Translate(new Vector2(dirX, 0.0f) * playerSpeed * Time.deltaTime);

        // Jump system
        if (mCheckGround.checkGround(gameObject.transform, playerJumpAltitude))
        {
            anim.SetBool("isGrounded", true);
            Jump();
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }





    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rgb.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
            //anim.SetBool("isJumping", true);

        }
    }


}
