using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //save starting postition of the background to a Vector3 variable
        startPosition = transform.position;

        //set the repeatWidth to half of the width of the background using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the background is futher to the left than the repeatWidth, reset it to start position
        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }

    }
}
