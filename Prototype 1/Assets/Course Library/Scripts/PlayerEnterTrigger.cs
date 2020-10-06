using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 2)
* (Detects when enter triggerzone)
*/

//Attach to player
public class PlayerEnterTrigger : MonoBehaviour
{
   // public Text textbox;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone"))
        {
            //set the textbox text to "You Win!"
            //textbox.text = "You Win!";
            ScoreManager.score++;
        }
    }

}
