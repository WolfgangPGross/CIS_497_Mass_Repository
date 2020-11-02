using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 2)
* (Dectects Collisions with triggers)
*/

//attach to food prefab
public class DetectCollision : MonoBehaviour
{
    private ScoreManager displayScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone Good"))
        {
            //set the textbox text to "You Win!"
            //textbox.text = "You Win!";
            ScoreManager.score++;
        }
       else if (other.CompareTag("TriggerZone Bad"))
        {
            //set the textbox text to "You Win!"
            //textbox.text = "You Win!";
            ScoreManager.gameOver = true;
            ScoreManager.score++;
        }
    }
}
