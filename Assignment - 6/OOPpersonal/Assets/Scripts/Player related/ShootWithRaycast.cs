using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycast : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public Camera cam;

    //public ParticleSystem magicFlash;

    public float hitForce = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //magicFlash.Play();
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            //tell you what you hit
            Debug.Log(hitInfo.transform.gameObject.name);

            /*//Get the Target script off the hit object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();*/

            //Get the Enemy script off the hit object
            Golem targetG = hitInfo.transform.gameObject.GetComponent<Golem>();
            Sentinal targetS = hitInfo.transform.gameObject.GetComponent<Sentinal>();
            Obstacle targetO = hitInfo.transform.gameObject.GetComponent<Obstacle>();


            //If a target script was found, make the target take damage
            if (targetG != null)
                targetG.TakeDamage(damage);
            if (targetS != null)
                targetS.TakeDamage(damage);
            if (targetO != null)
                targetO.TakeDamage(damage);


            //If the shot hits a RigidBody, apply a force
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
