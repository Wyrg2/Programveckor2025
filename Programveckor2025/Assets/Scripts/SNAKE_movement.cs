using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNAKE_movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D snakerb;
    SpriteRenderer sprite;
    public float speed;
    bool flipXrot = false;
    void Start()
    {
        snakerb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        snakerb.velocity = new Vector2(speed,snakerb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed = -speed;
            flipXrot = !flipXrot;
            sprite.flipX = flipXrot;
        }
    }
}
