using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    public bool isGrounded;

    public bool playerFreeze;

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 5;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckLeft;

    [SerializeField]
    Transform groundCheckRight;

    public Transform spawnpoint;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerFreeze = true;

        //groundCheck = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {





    //Kill the enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if(hit != null)
        {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("die");
                Destroy(hit.collider.gameObject);
            }
        }


        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            //Debug.Log("isgrounded");
            isGrounded = true;
            playerFreeze = true;
        }
        else
        {
            //Debug.Log("isNotgrounded");
            isGrounded = false;
        }

        if (playerFreeze)
        {
            if (Input.GetKey("left"))
                    {

                        if (isGrounded)
                        {
                            animator.Play("player_run");
                        }
                        rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                        spriteRenderer.flipX = true;

                    }
                    else if(Input.GetKey("right"))
                    {

                        if (isGrounded)
                        {
                            animator.Play("player_run");
                        }
                        rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                        spriteRenderer.flipX = false;

                    }
                    else
                    {
                        if (isGrounded)
                        {
                             animator.Play("player_idle");
                        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                        }
           
                    }

                    if (Input.GetKey("up") && isGrounded)
                    {
                        //Debug.Log("jump");

                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                        animator.Play("player_jump");
                    }

        }
        else
        {
            animator.Play("player_jump");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            //Destroy(this.gameObject);
            Respawn();
        }
    }

    public void Respawn()
    {
        this.transform.position = spawnpoint.position;
        playerFreeze = false;
        Life.health -= 1;
    }


  

}
