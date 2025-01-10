using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float BellManSpeed;
    void Start()
    {
        transform.position = new Vector2(0, -2.8f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            if(BellManSpeed< 10)
            {
                BellManSpeed += 0.2f;
            }
            rb.velocity = new Vector2(-BellManSpeed, 0);
            if (BellManSpeed > 0)
            {
                BellManSpeed -= 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(BellManSpeed < 10) 
            {
                 BellManSpeed += 0.2f;
            }
            rb.velocity = new Vector2(BellManSpeed,0);
            if(BellManSpeed > 0)
            {
                BellManSpeed -= 0.2f;
            }
        }
    }
}
