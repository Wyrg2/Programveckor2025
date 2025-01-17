using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{

    bool canTeleport = false;
    int whatplaceyouendupin;

    // Start is called before the first frame update
    private void Start()
    {
        whatplaceyouendupin = Random.Range(1, 5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && canTeleport == true)
        {
            SceneManager.LoadScene(whatplaceyouendupin);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTeleport = true;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = false;
    }

   
}
