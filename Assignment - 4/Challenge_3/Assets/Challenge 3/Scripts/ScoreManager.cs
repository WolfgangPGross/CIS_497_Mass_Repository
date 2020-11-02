using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* (Wolfgang Gross)
* (Assignment 4)
* (Manages the score)
*/

public class ScoreManager : MonoBehaviour
{
    public static bool OURgameOver;
    public static bool won;
    public static int score;
    public static bool gameOver;

    private PlayerControllerX playerControllerScript;

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        gameOver = false;
        OURgameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playerControllerScript.gameOver)
        {
            
            score = playerControllerScript.score;
            textbox.text = "Score: " + score;
        }
        if (playerControllerScript.score >= 10)
        {
            won = true;
            gameOver = true;
        }
        if (playerControllerScript.gameOver)
        {
            if (won)
            {
                textbox.text = "You win! " +
                    "Press R to try again!";
            }
            else
            {
                textbox.text = "You lose! " +
                    "Press R to try again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
