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
    private PlayerMovement playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the textbox text to "You Win!"
            //textbox.text = "You Win!";
            playerController.inEndZone = true;
        }
    }

}
