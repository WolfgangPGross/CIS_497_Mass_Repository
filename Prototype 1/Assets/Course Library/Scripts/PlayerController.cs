using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 2)
* (Controlls the player)
*/

public class PlayerController : MonoBehaviour
{
    //These can be public for usage
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Left/Right Input
        horizontalInput = Input.GetAxis("Horizontal");

        //Get Forward/Back Input
        forwardInput = Input.GetAxis("Vertical");

        //Move the Vehicle Forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Turn the Vehicle
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
