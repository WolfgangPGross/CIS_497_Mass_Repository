using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode forceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound; 
 
    // Start is called before the first frame update
    void Start()
    {
        //Set reference variables to components
        playerAudio = GetComponent<AudioSource>();

        //Set reference variables to components
        playerAnimator = GetComponent<Animator>();

        //Start Running
        playerAnimator.SetFloat("Speed_f", 1.0f);

        //Set reference variables to components
        rb = GetComponent<Rigidbody>();

        forceMode = ForceMode.Impulse;

        //Modify gravity
        //Physics.gravity *= gravityModifier;

        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Press spacebar to jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;

            //Set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //Stop the dirt particle
            dirtParticle.Stop();

            //Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            //play dirt particle
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //Play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //Play explosion particle
            explosionParticle.Play();

            //Stop playing dirt particle
            dirtParticle.Stop();
        }
    }
}
