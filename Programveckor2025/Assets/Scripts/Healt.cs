using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healt : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    private int playerDamageTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerDamageTimer = 500;
    }



    private void Update()
    {
        if(playerDamageTimer > -1)
        {
            playerDamageTimer -= 1;
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (playerDamageTimer == -1)
            {
                TakeDamage(2);
                playerDamageTimer = 200;
            }

        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
               SceneManager.LoadScene(0);
        }
    }



}
