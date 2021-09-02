using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinoController : MonoBehaviour
{

    public float velocityX = 15;
    // Start is called before the first frame update
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    
    //Const
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_DESLIZAR = 2;
    private const int ANIMATION_SALTAR = 3;
    private const int ANIMATION_MUERTO = 4;

    
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(ANIMATION_QUIETO);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX,rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CORRER);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX,rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(ANIMATION_CORRER);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.right*velocityX;
            sr.flipX = false;
            ChangeAnimation(ANIMATION_DESLIZAR);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*40,ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
            
        }
        
        if (Input.GetKeyUp(KeyCode.X))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(ANIMATION_MUERTO);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("Collision" + collision.gameObject.tag);
        
        
        if (collision.gameObject.layer == 10)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
            //ChangeAnimation(ANIMATION_MUERTO);
        }
        
    }
    
    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    
    
}
