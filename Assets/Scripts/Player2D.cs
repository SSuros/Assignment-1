using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] float speed = 1;
    bool isGrounded = false;
    bool jump = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpPower = 2;

    const float grounCheckRadius = 0.1f;
    Rigidbody2D rb;
    float horizontalValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }else if(Input.GetButtonUp("Jump"))
        {
            jump = false; 
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        isGrounded = false; 

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, grounCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
    }

    void Move(float dir,bool jumpFlag)
    {
        if(isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }

        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
    
}

