using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManArena2Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float BellManSpeed;
    private float Direction;
    private int JumpsLeft;
    void Start()
    {
        transform.position = new Vector2(-0.72f, -0.87f);
        rb = GetComponent<Rigidbody2D>();
        JumpsLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(JumpsLeft);
        Direction = (Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(Direction * 5, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpsLeft = 2;
        }
    }
}
