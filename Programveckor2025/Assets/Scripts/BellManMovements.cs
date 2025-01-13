using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float Direction;
    void Start()
    {
        transform.position = new Vector2(0, -2.8f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Script
       if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (Vector3.left*10) * Time.deltaTime;
        }
       if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (Vector3.right*10)* Time.deltaTime;
        }
       if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 25);
        }

    }
}
