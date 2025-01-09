using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        transform.position = new Vector2(0, -2.8f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.velocity += new Vector2(-50, 0);
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.velocity += new Vector2(50, 0);
        }
    }
}
