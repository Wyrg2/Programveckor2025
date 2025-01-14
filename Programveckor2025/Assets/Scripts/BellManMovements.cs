using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    Rigidbody2D rb;
    private float Direction;
    public float jumpHeight;
    bool isGrounded;
    bool canDoubleJump;

    int JumpsLeft;
    Animator Animate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, 0);
        Speed = 0;
        Animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Left and right movement script
        Direction = (Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Direction = (Input.GetAxis("Horizontal"));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Direction = (Input.GetAxis("Horizontal"));
        }
        rb.velocity = new Vector2(Direction * 10, rb.velocity.y);


        //Animation Responsible Code
        if (Direction == 0)
        {}

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Animate.Play("Walking");
        }
        else
        {
            Animate.Play("New idle");
        }

        //Jump Script
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        //Double Jump Script
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump == true)
        {
            doubleJump();
            canDoubleJump = false;
        }


    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void doubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 0.75f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            canDoubleJump = true;
        }
    }
}
   
