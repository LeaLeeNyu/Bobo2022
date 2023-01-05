using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int timeScore;
    public static int coinsCount;

    //UI
    [SerializeField] private GameObject starOne;
    [SerializeField] private GameObject starTwo;
    [SerializeField] private GameObject starThree;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeScoreT;
    [SerializeField] private TMP_Text coinsScoreT;
    [SerializeField] private AudioSource winSound;

    [HideInInspector] public bool gameEnd = false;


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
            winSound.Play();

            gameEnd = true;
            //display the score
            scoreText.text = countScore().ToString();

            //display time
            float time = Mathf.Round(ScoreTimer.levelTime * 1f);
            string timeString = time.ToString() + "s / " + timeScore.ToString();
            timeScoreT.text = timeString;

            //display coins 
            coinsScoreT.text = coinsCount.ToString();

            //display star
            if(score > 80)
            {
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(true);
            }
            else if (score > 50)
            {
                starOne.SetActive(false);
                starTwo.SetActive(false);
            }
            else
            {
                starOne.SetActive(false);
            }
        }
            
    }

    private int countScore()
    {
        ScoreTimer.countTime = false;


        //complete the mission +50
        score += 50;

        //count the time score +30 - 15
        if(ScoreTimer.levelTime > 600)
        {
            timeScore = 15;
        }
        else if (ScoreTimer.levelTime > 300)
        {
            timeScore = 25;
        }
        else
        {
            timeScore = 30;
        }

        score += timeScore;

        //count the coin score, collected all 20 coins +20
        score += coinsCount;

        //Start Canvas Animator
        scoreAnimator.SetBool("Finish", true);

        return score;
    }
}
