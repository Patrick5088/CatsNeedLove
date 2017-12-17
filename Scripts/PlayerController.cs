using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public Transform groundCheck;
    public float jumpForce = 1000f;
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb;
    private void Awake()
    {
    
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("isJumping", !grounded);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        
        anim.SetFloat("Speed", Mathf.Abs(h));
        if(h*rb.velocity.x < maxSpeed)
        {
            rb.AddForce(Vector2.right * h * moveForce);
        }
        if(Mathf.Abs(rb.velocity.x)>maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else
        if(h < 0&& facingRight)
        {
            Flip();
        }
            
        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }
        
           
        Animating(h, 0.0f);


    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Animating(float h,float v)
    {
        bool walking = false;
        //bool walking = h != 0 || v != 0;
        if (rb.velocity.magnitude != 0)
        {
            walking = true;
        }
        anim.SetBool("isMoving",walking);
        
    }
    
}
