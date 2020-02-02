using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    Animator animator;
    public float speed;
    public bool MoveRight;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Transform enemyHead;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.Play("enemy_walk");

        if (MoveRight)
        {
            
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            //transform.localScale = new Vector2(1, 1);
        }
        else
        {
            
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            //transform.localScale = new Vector2(-1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turns"))
        {
            if (MoveRight)
            {
                
                MoveRight = false;
                spriteRenderer.flipX = true;
            }
            else
            {
                MoveRight = true;
                spriteRenderer.flipX = false;
            }



        }

    }
    }


