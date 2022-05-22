using UnityEngine;
// [!] REQUIRED COMPONENTS.
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    // IMPORTANT variables.
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpForce;
    [SerializeField] private float playerJumpAltitude;
    // Private variables.
    private Rigidbody2D rgb;
    private SpriteRenderer spr;
    private Animator anim;
    public bool leftHold, rightHold;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (leftHold)
        {
            spr.flipX = true;
            anim.SetBool("isRunning", true);
            transform.Translate(new Vector2(-1, 0.0f) * playerSpeed * Time.deltaTime);
        }
        if (rightHold)
        {
            spr.flipX = false;
            anim.SetBool("isRunning", true);
            transform.Translate(new Vector2(1, 0.0f) * playerSpeed * Time.deltaTime);
        }

    }

    public void holdLeft()
    {
        leftHold = true;
    }

    public void holdRight()
    {
        rightHold = true;
    }

    public void noHold()
    {
        leftHold = false;
        rightHold = false;
    }

    public void Jump()
    {
        if (mCheckGround.checkGround(gameObject.transform, playerJumpAltitude))
        {
            rgb.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fall"))
        {
            Player.playerSave();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Player.playerSave();
        }
    }

}
