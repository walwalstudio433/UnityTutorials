using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLeft : MonoBehaviour
{
    public Text tScore;
    public Text bScore;
    public int score;

    public int bronzeScore;
    public int silverScore;
    public int goldScore;
    public Image image;
    public Sprite bronzeMedal, silverMedal, goldMedal;

    public AudioClip scoreSound;
    // Use this for initialization
    void Start()
    {
        score = 0;
        tScore.GetComponent<Text>().text = score.ToString();
        //bScore.GetComponent<Text>().text = BestScore.bestScore.ToString();
        bScore.GetComponent<Text>().text = PlayerPrefs.GetInt("bestScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = scoreSound;
        audio.Play();
        //Debug.Log("collider");
        Destroy(other.gameObject);

        score++;
        if (score > PlayerPrefs.GetInt("bestScore")) {
            PlayerPrefs.SetInt("bestScore", score);
            //BestScore.bestScore = score;
            bScore.GetComponent<Text>().text = PlayerPrefs.GetInt("bestScore").ToString();
        }

        medaling();

        tScore.GetComponent<Text>().text = score.ToString();
        if(score%3 == 0) MakingHurdle.faster();
        if (score %3 == 0) MakingTopHurdle.faster();        
    }

    private void medaling()
    {
        if (score == bronzeScore )
        { //동메달

            image.sprite = bronzeMedal;
        }
        else if (score == silverScore )  //은
        {
            image.sprite = silverMedal;
        }
        else if (score == goldScore) //금
        {
            image.sprite = goldMedal;

        }
    }
}
