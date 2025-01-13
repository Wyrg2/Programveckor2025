using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float Direction;
    
    public float BellManSpeed;
    public float BellmanMaxSpeed;
    public float Retardera;
    public float jumpHeight;
    public float fallMultiplier;
    
    bool isGrounded;
    bool canDoubleJump;

    Vector2 gravity;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         gravity = new Vector2(rb.velocity.x, jumpHeight/2);
    }

    // Update is called once per frame
    void Update()
    {
        
       
        falling();
        
        //Movement
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector2(BellManSpeed, rb.velocity.y);
            
            if(BellManSpeed< BellmanMaxSpeed)
            {
                BellManSpeed += Retardera;
            }
            rb.velocity = new Vector2(-BellManSpeed, 0);
            if (BellManSpeed > 0)
            {
                BellManSpeed -= Retardera;
            }
            
            falling();
        }
       if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        { 
            falling();
            
            isGrounded = true;
            
            if(BellManSpeed < BellmanMaxSpeed) 
            {
                 BellManSpeed += Retardera;
            }
            rb.velocity = new Vector2(BellManSpeed,0);
            if(BellManSpeed > 0)
            {
                BellManSpeed -= Retardera;
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            Jump();
            falling();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump == true)
        {
            DoubleJump();
            canDoubleJump = false;
            falling();
        } 
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, (jumpHeight * 0.75f));
    }

    void falling()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity -= gravity * fallMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            canDoubleJump = true;
        }
       if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 25);
        }

    }
}
