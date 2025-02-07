using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int damage = 2;
    public TextMeshProUGUI Texthealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Texthealth.text = "Enemy's Health: " + currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(6);
        }

        Texthealth.text = "Enemy's Health: " + currentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(damage);
        }
    }

}
