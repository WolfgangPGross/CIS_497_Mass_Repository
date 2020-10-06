using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* (Wolfgang Gross)
* (Assignment 2)
* (Manages the Score)
*/

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;


    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        if(score >= 3)
        {
            won = true;
            gameOver = true;
        }
        if(gameOver)
        {
            if(won)
            {
                textbox.text = "You win! " +
                    "Press R to try again!";
            }
            else
            {
                textbox.text = "You lose! " +
                    "Press R to try again!";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }
}
