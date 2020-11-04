using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinal : Enemy
{
    protected int damage;

    public Rigidbody rigid;

    protected override void Attack()
    {
        Debug.Log("Sentinal Attack!");
        
        //Fire projectile prefab that adds force to player
    }


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 30;
        
        if (health == 30)
        {
            Attack();
        }

    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Sentinal took " + amount + " points of damage!");
        health -= amount;
        if (health <= 0)
        {
            doDeath();
        }
        if (health < 30)
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
        GameManager.Instance.score += 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottom"))
        {
            doDeath();
        }
    }
}
