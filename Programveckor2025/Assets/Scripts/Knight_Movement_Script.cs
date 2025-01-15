using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement_Script : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject BellMan;
    private int KnightDirection;
    Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(10.7f, -1.09f);
        KnightDirection = -10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2((transform.position.x) + (KnightDirection * Time.deltaTime), -1.09f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            KnightDirection *= -1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
