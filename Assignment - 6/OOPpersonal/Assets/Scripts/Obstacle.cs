using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Enemy
{
    protected int damage;

    public Rigidbody rigid;

    protected override void Attack()
    {
        //Do nothing
    }


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 50;
        //GameManager.score = 5;
        //GameManager.Instance.score += 2;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Obstacle took " + amount + " points of damage!");
        health -= amount;
        if (health <= 0)
        {
            doDeath();
        }
        if (health < 50)
        {
            if (this.rigid != null)
            {
                this.rigid.useGravity = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void doDeath()
    {
        
        Destroy(gameObject);
        GameManager.Instance.score += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottom"))
        {
            doDeath();
        }
    }
}
