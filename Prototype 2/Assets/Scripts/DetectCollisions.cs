using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Detects when collide with triggerzone)
*/

//attach to food prefab
public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);

        displayScoreScript.score++;
    }
}
