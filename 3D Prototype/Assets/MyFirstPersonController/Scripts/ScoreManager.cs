using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* (Wolfgang Gross)
* (Assignment 5)
* (Manages the score)
*/

public class ScoreManager : MonoBehaviour
{
    public static bool OURgameOver;
    public static bool won;
    public static int score;
    public static bool gameOver;

    private PlayerMovement playerController;

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameOver = false;
        OURgameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = playerController.gameOver;
        score = playerController.score;

        if (!playerController.gameOver)
        {

            score = playerController.score;
            textbox.text = "Score: " + score;
        }
        if (score >= 10)
        {
            won = true;
            //gameOver = true; //settrue only if in endzone with score >= 10
        }
        if (playerController.inEndZone == true)
        {
            if (won && playerController.score >= 60)
            {
                textbox.text = "You're poor mouse! You win? " +
                    "Press R to play again!";
            }
            else if (won)
            {
                textbox.text = "You win! " +
                    "Press R to play again!";
            }
            else if (playerController.score == 0)
            {
                textbox.text = "Pacifist Victory?! " +
                    "Press R to play again!";
            }
            else
            {
                textbox.text = "You lose! " +
                    "You didn't break 10 objects, " +
                    "Press R to try again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
