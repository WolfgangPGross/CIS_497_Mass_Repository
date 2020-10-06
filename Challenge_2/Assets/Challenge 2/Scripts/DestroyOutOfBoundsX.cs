using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Destroys objects out of bounds)
*/

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -35;
    private float bottomLimit = -1;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            //lose hp/lose game
            //
            scoreManager.hp--;
            Destroy(gameObject);
        }

    }
}
