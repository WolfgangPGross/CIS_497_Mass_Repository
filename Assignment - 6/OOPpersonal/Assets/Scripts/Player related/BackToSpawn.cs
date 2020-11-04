using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    public GameObject spawn;
    public Vector3 spawnPos;

    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Attack1")) //Golem Push
        {
            controller.Move(spawnPos);
        }
    }
}
