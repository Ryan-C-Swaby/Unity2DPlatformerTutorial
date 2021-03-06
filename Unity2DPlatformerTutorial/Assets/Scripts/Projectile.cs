using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private float direction;
    private float lifeTime;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            return;
        }

        float movementSpeed = Speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;

        if(lifeTime > 5)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "CameraConfiner")
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + .22f, transform.localPosition.z);
            hit = true;
            boxCollider.enabled = false;
            animator.SetTrigger("Explode");
        }
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
        lifeTime = 0;
    }
}
