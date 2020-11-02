using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 3)
* (Controls the player)
*/

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {

                StartCoroutine(WaitSecond());
               
            }
            
        }
    }

    IEnumerator WaitSecond()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(1.0f);
        canShoot = true;
    }
}
