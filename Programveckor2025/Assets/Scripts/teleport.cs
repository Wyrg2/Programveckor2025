using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    // Start is called before the first frame update

    float whatplaceyouendupin;

    void Start()
    {
        whatplaceyouendupin = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (collision.gameObject.tag== "Player")
            {
                if (whatplaceyouendupin == 1)
                {
                    SceneManager.LoadScene(1);
                }

                if (whatplaceyouendupin == 2)
                {
                    SceneManager.LoadScene(2);
                }

                if (whatplaceyouendupin == 3)
                {
                    SceneManager.LoadScene(3);
                }

                if (whatplaceyouendupin == 4)
                {
                    SceneManager.LoadScene(4);
                }
            }
        }
        
    }

}
