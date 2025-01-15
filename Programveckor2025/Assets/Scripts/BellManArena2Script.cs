using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BellManArena2Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float BellManSpeed;
    private float Direction;
    private int JumpsLeft;
    private Animator animate;
    void Start()
    {
        transform.position = new Vector2(-0.72f, -0.87f);
        rb = GetComponent<Rigidbody2D>();
        JumpsLeft = 0;
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // This code is responsible for movement
        Direction = (Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(Direction * 7.5f, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if(JumpsLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 10);
                JumpsLeft -= 1;
            }
        }
        //This code is responsible for animations
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.y == 0)
            {
                animate.Play("BellManMove");
            }
        }
        else
        {
            if(rb.velocity.y == 0)
            {
                animate.Play("BellManIdle");
            }
        }


        if(Direction > 0)
        {
            transform.localScale = new Vector2(-10, 10);
        }
        
        if (Direction < 0)
        {
            transform.localScale = new Vector2(10, 10);
        }


        if (rb.velocity.y > 5)
        {
            animate.Play("BellManUp");
        }
        if(rb.velocity.y < 5 && rb.velocity.y > -1 && JumpsLeft < 2)
        {
            animate.Play("BellManUpMiddle");
        }
        if(rb.velocity.y < 0 && JumpsLeft < 2)
        {
            animate.Play("BellManFalling");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpsLeft = 2;
        }
    }
}
