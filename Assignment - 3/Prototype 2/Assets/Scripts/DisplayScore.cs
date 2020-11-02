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
public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    private SpawnManager spawnManager;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;
       
        if (score >= 10)
        {
            spawnManager.gameOver = true;
        }
     
        if(spawnManager.gameOver)
        {
            if(score < 10)
            {
                textbox.text = "Game Over, Press R to try again!";
            }
            else if (score >= 10)
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
