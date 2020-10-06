using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* (Wolfgang Gross)
* (Assignment 4)
* (Controlls the player)
*/

public class PlayerControllerX : MonoBehaviour
{
    public int score = 0;

    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ForceMode forceMode;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boing;

    private ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>() ;

        forceMode = ForceMode.Force;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, forceMode);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            
            Destroy(other.gameObject);
            //Destroy(gameObject);
            gameOver = true;
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

            score++;
        }
        if(!gameOver)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                // Apply a small upward force at touching the ground
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                playerAudio.PlayOneShot(boing, 1.0f);
            }

            else if (other.gameObject.CompareTag("Top"))
            {
                // Apply a small upward force at touching the ground
                playerRb.AddForce(Vector3.down * 15, ForceMode.Impulse);
            }
        }
        
    }

}
