using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
    
   
{
    public static int score = 0;
    static int scoreGoal = 1;

    void OnGUI()
    {
        GUILayout.Box("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= scoreGoal)
        {
            score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Winner");
        }
    }
}