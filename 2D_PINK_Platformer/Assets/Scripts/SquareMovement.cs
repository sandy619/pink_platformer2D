using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] Collider2D playerCollider;
    Vector2 direction;
    [SerializeField] Animator anim;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<Collider2D>();

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        Flip();
        Jump();
    }


    
    void Move()
    {
        float xDir = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;


        direction = new Vector2(xDir, rb.velocity.y);

        rb.velocity = direction;
        print(rb.velocity);

    }

    void Flip()
    {
        bool isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Jump()
    {
        //if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        //{
        //    return;
        //}

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0, jumpHeight);
            rb.velocity += jumpVelocity;
        }
    }
}
