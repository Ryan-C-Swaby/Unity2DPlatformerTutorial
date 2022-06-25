using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput;
   

    public float RunSpeed;
    public float JumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        MoveLeftOrRight();

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void MoveLeftOrRight()
    {
        body.velocity = new Vector2(horizontalInput * RunSpeed, body.velocity.y);

        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("Run", horizontalInput != 0);
    }

    void Jump()
    {
        animator.SetBool("Grounded", false);
        animator.SetTrigger("Jump");
        body.velocity = new Vector2(body.velocity.x, JumpHeight);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            animator.SetBool("Grounded", true);
        }
    }

    private bool IsGrounded()
    {
        return animator.GetBool("Grounded");
    }

    public bool CanAttack()
    {
        return horizontalInput == 0f && IsGrounded();
    }
}
