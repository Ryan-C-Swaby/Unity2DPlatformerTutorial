using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer renderer;

    public float RunSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
          var horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * RunSpeed, body.velocity.y);

        if(horizontalInput > 0f)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }
    }
}
