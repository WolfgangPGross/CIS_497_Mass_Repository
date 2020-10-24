using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public PlayerMovement playerController;

    public float health = 50f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerController.score++;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
