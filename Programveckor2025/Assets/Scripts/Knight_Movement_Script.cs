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
        transform.position = new Vector2(12.1f, -1.22f);
        KnightDirection = -3;
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Code
        transform.position += (Vector3.left* KnightDirection * Time.deltaTime);
        if((transform.position.x > 12.31f && KnightDirection == -3) || (transform.position.x < -12.07f && KnightDirection == 3))
        {
            KnightDirection *= -1;
        }
        




        // Animation Code
        if(KnightDirection == 3)
        {
            transform.localScale = new Vector2(-15, 15);
        }

        if(KnightDirection == -3)
        {
            transform.localScale = new Vector2(15, 15);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animate.Play("KnightAttack");
        }
        else
        {
            animate.Play("Knight Boss Dude");
        }
    }
}
