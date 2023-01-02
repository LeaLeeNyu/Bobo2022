using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public static int coinsCount;

    //UI 
    [SerializeField] private GameObject starOne;
    [SerializeField] private GameObject starTwo;
    [SerializeField] private GameObject starThree;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeScore;
    [SerializeField] private TMP_Text coinsScore;


    //Canvas Animator
    private Animator scoreAnimator;

    private void Awake()
    {
        scoreAnimator = GameObject.Find("Finish").GetComponent<Animator>();
    }

    //if player collide with destination collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            countScore();
        }
            
    }

    private int countScore()
    {
        ScoreTimer.countTime = false;


        //complete the mission +50
        score += 50;

        //count the time score +30 - 15
        if(ScoreTimer.levelTime > 1200)
        {
            score += 15;
        }else if (ScoreTimer.levelTime > 600)
        {
            score += 25;
        }
        else
        {
            score += 30;
        }

        //count the coin score, collected all 20 coins +20
        score += coinsCount;

        //Start Canvas Animator
        scoreAnimator.SetBool("Finish", true);

        return score;
    }
}
