using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Collider2D feetCollider;
    Vector2 direction;
    [SerializeField] Animator anim;
    bool playerIsAlive = true;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    void FixedUpdate()
    {
        if (!playerIsAlive)
            return;

        Move();
        Flip();

    }

     void Update()
    {
        if (!playerIsAlive)
            return;

        Jump();
    }

    void Move()
    {
        float xDir = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        anim.SetFloat("Speed", Mathf.Abs(xDir));

        direction = new Vector2(xDir, rb.velocity.y);
        
        rb.velocity = direction;
         
    }

    void Flip()
    {
        bool isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Jump()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0, jumpHeight);
            rb.velocity += jumpVelocity;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag=="Enemy")
       {
            Death();

       }
   }

    public void Death()
    {
        playerIsAlive = false;
        rb.velocity = new Vector2(1f, 3.5f);
        //playerCollider.isTrigger = true;
        //feetCollider.isTrigger = true;
        Destroy(playerCollider);
        Destroy(feetCollider);


        anim.SetBool("isAlive", false);

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        StartCoroutine(ReloadLevel());
       
    }

    IEnumerator ReloadLevel()
    {
        
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }





}
