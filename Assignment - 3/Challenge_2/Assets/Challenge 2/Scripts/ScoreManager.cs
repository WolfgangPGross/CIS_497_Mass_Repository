using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Displays the score)
*/

//Attach to a Text UI object
public class ScoreManager : MonoBehaviour
{
    public Text textbox;
    //private SpawnManagerX spawnManager;

    public int score = 0;
    public int hp = 3;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        int tempScore = score / 2;
        textbox.text = "Score: " + tempScore;

        if(hp == 0)
        {
            gameOver = true;
        }

        if (tempScore >= 5)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            if(hp == 0)
            {
                textbox.text = "Game Over, You lost all hp! Press R to try again";
            }
            else if (tempScore >= 5)
            {
                textbox.text = "You WIN! Press R to try again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
