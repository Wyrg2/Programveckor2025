using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    Rigidbody2D rb;
    private float Speed;
    private float Direction;
    int JumpsLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, 0);
        Speed = 0;
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
        if(Direction == 0)
        {
           
        }

        //Jump Script
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            if(JumpsLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 10);
                JumpsLeft -= 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // detects if the player is touching the ground so the player will not be able to jump forever
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpsLeft = 2;
        }
    }
}
