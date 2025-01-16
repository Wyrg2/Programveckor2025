using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BellManMovements : MonoBehaviour
{
    Rigidbody2D rb;
    
    private float Direction;
    public float jumpHeight;
    public float cooldown = 0.5f;
    float timer = 0;
    public float bulletspeed;
    
    public GameObject projectilePrefab;
    public GameObject shooter;
    
    bool isGrounded;
    bool canDoubleJump;
    
    Animator Animate;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
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

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Animate.SetBool("isWalking", true);
        } 
        else
        {
            Animate.SetBool("isWalking", false);
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

        //Shooting script
        if (Input.GetMouseButton(0) && timer<=0)
        {
           
            GameObject bullet = Instantiate(projectilePrefab, shooter.transform.position, Quaternion.identity);
            bullet.GetComponent<ProjectileBehaviour>().direction= Direction*bulletspeed;
            if (Direction==0)
            {
                bullet.GetComponent<ProjectileBehaviour>().direction = bulletspeed;
            }
            timer = cooldown;
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        Animate.SetBool("isJumping", true);
        Animate.SetBool("isJumping", false);
        Animate.SetBool("isFalling", true);
    }

    void doubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 0.75f);
        Animate.SetBool("isDoublejumping", true);
        Animate.SetBool("isFalling", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Animate.SetBool("isFalling", false);
            Animate.SetBool("isDoublejumping", false);
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
   
