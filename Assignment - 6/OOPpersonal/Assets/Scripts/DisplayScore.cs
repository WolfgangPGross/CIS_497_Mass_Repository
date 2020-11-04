using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public int score;

    bool endCheck;

    public Text textbox1; //display score in corner
    public Text textbox2; //fluff and total score
    public Text textbox3; //win/lose cond + how well if win
    public Text textbox4; //press r to restart


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.Instance.score;
        endCheck = GameManager.Instance.gameOver;
        if (!endCheck) // update on score -> check if in other class, dont lose score on gameOver
        {
            textbox1.text = "Score: " + score;

            textbox2.text = " ";
            textbox3.text = " ";
            textbox4.text = " ";
        }
        else
        {
            textbox2.text = "You Got through with a total score of " + score;
            if (score >= 60)
            {
                textbox3.text = "You did AMAZING!";
            }
            else if (score < 60 && score > 20)
            {
                textbox3.text = "You did decently!";
            }
            else
            {
                textbox3.text = "You didn't get enough points in the end :(";
            }
            textbox4.text = "Press R to try again!";

        }
    }
}
