using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Detects when collision is had)
*/

public class DetectCollisionsX : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(other.gameObject);
        //Destroy(gameObject);
        //scoreManager.score++;
        scoreManager.score++;
    }
}
