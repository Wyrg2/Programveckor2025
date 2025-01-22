using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int damage = 2;
    public float whentogoback = 3;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (whentogoback <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void TakeDamage(int amout)
    {
        currentHealth -= amout;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            whentogoback -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(damage);
        }
    }

}
