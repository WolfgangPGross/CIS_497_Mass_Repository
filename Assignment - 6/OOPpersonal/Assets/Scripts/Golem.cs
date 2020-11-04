using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;

    //public Rigidbody rigid;

    protected override void Attack()
    {
        Debug.Log("Golem Attack!");

        //Fire projectile prefab that adds force to player

    }


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 40;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Golem took " + amount + " points of damage!");
        health -= amount;
        if (health <= 0)
        {
            doDeath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void doDeath()
    {
        GameManager.Instance.score += 5;
        Destroy(this.gameObject);
        
    }
}
