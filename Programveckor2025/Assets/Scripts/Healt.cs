using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healt : MonoBehaviour
{
    public int currenthealth;
    public int maxHealth = 10;
    public int damage = 1;
    public TextMeshProUGUI playerHealthText;
    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        playerHealthText.text = "Your Health: " + currenthealth;
    }



    private void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damage);
        }
    }
    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if(currenthealth <= 0)
        {
               SceneManager.LoadScene(5);
        }

        playerHealthText.text = "Your Health: " + currenthealth;
    }



}
