using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Destroy prefabs when out of bounds)
*/

//add to food and animal prefabs

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private SpawnManager spawnManager; 

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //seperating the food from the animals going out of bounds
        //Food goes out of bounds
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //Animal goes out of bounds
        if (transform.position.z < bottomBound)
        {
            spawnManager.gameOver = true;
            
            Debug.Log("Game Over!");

            Destroy(gameObject);
        }


    }
}
