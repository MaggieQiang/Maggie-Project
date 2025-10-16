using UnityEditor.Animations;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 6f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpPower = 5f;

    bool jumping = false;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", movementX != 0f);

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y; //In 2D we don't need to worry about Y

        Debug.Log(v);
    }

    void OnJump()
    {
        if (touchingGround)
        {
            jumping = true;
        }
    }
    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed;
        //float YmoveDistance = movementY * speed;

        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);

        rb.linearVelocityX = XmoveDistance;
        //rb.linearVelocityY = movementY * 10f;
        //rb.linearVelocity = new Vector2(movementX, movementY).normalized;

        if (touchingGround && jumping)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            jumping = false;
        }

    }
    bool touchingGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
        }
    }
    private void ConCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = false;
        }
    }
    

}
