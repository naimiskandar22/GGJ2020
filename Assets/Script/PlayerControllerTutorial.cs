using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTutorial : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    public bool isGrounded;

    public bool isWall;

    public bool playerFreeze;

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 3;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckLeft;

    [SerializeField]
    Transform groundCheckRight;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerFreeze = true;
        Time.timeScale = 1;
        //groundCheck = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        //Kill the enemy
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down);

        if (hit)
        {
            //Debug.Log("HITSSS" + hit.collider.gameObject.name);

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("die");

                rb2d.velocity = new Vector2(rb2d.velocity.x, 1);
                Destroy(hit.collider.gameObject);
            }
        }

        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Wall"))) ||
                (Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Wall"))) ||
                (Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Wall"))))
        {
            isWall = true;
            playerFreeze = true;
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
                    animator.Play("character_walk");
                }
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                spriteRenderer.flipX = true;

            }
            else if (Input.GetKey("right"))
            {

                if (isGrounded)
                {
                    animator.Play("character_walk");
                }
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                spriteRenderer.flipX = false;

            }
            else
            {
                if (isGrounded)
                {
                    animator.Play("character_idle");
                    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                }

            }

            if (Input.GetKey("up") && isGrounded)
            {
                //Debug.Log("jump");

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                animator.Play("character_jump");
            }

        }
        else
        {
            animator.Play("character_jump");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


    }
}
