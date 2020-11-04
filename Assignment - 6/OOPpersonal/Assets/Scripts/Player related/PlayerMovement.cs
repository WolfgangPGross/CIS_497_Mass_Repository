using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    //variables for gravity
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float jumpHeight = 3f;

    public int score = 0;
    public bool gameOver = false;
    public bool playerDead = false;
    public bool inEndZone = false;

    public GameObject spawn;
    public Vector3 spawnPos;

    private void Awake()
    {
        gravity *= gravityMultiplier;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = spawn.transform.position;
        Debug.Log("SpawnPos: " + spawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Get Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //add jump code before we calculate gravity velocity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //add gravity to velocity after jumping
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);




    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Attack1")) //Reset to spawn Attack
        {
            if (GameManager.Instance.gameOver != false)
            {
                if (GameManager.Instance.score >= 3)
                {
                    GameManager.Instance.score -= 3;
                    //GameManager.Instance.score--;
                }
                else if (GameManager.Instance.score > 0 && GameManager.Instance.score < 3)
                {
                    GameManager.Instance.score = 0;
                }
            }

            Debug.Log("Back to spawn");

            Vector3 moveVector = spawnPos - this.transform.position;
            
            controller.Move(moveVector);
        }
        
        if (other.CompareTag("Bottom")) //Reset to spawn Attack
        {
            if (GameManager.Instance.gameOver != false)
            {
                if (GameManager.Instance.score > 0)
                {
                    GameManager.Instance.score -= 1;
                }
            }

            Vector3 moveVector = spawnPos - this.transform.position;

            controller.Move(moveVector);
        }

        if (other.CompareTag("EndZone"))
        {
            GameManager.Instance.totalScore += GameManager.Instance.score;
            GameManager.Instance.gameOver = true;
        }
    }
}