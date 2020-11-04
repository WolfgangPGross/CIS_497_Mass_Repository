using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public DisplayScore displayScore;

    public float health = 30f;

    public Rigidbody rigid;


    // Start is called before the first frame update
    void Start()
    {
        displayScore = GameObject.Find("ScoreManager").GetComponent<DisplayScore>();
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        if (health < 30)
        {
            if(this.rigid != null)
            {
                this.rigid.useGravity = true;
            }
        }
    }

    void Die()
    {
        displayScore.score++;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
