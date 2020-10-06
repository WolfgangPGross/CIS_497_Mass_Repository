using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Manages all object spawns)
*/

//Attach to an empty game object
public class SpawnManager : MonoBehaviour
{
    //Drag the prefabs to spawn onto this array in the inspector
    public GameObject[] prefabsToSpawn;

    //Step 3:
    //Variables for spawn postion
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //Step 5:
        //Calls the method repeatedly ("Method", startDelay, spawnInterval)
        //InvokeRepeating("SpawnRandomPrefabs", 2, 1.5f);

        //Step 6
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
       /*if(Input.GetKeyDown(KeyCode.S))
        {
            //Step 4:
            // Move spawnRandomPrefab to own method
            SpawnRandomPrefab();


            // Step 1:
            //Spawn 0th prefab at top of screen
            //Instantiate(prefabsToSpawn[0], new Vector3(0, 0, 20), prefabsToSpawn[0].transform.rotation);
        
        }*/


    }

    void SpawnRandomPrefab()
    {
        //Generate index
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //Generate Spawn pos
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //Spawn the randomly selected prefab
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }


    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while(!gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(0.0f, 2.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }

}
