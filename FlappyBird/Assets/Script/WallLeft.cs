using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLeft : MonoBehaviour
{
    public Text tScore;
    public Text bScore;
    public int score;

    public AudioClip scoreSound;
    // Use this for initialization
    void Start()
    {
        score = 0;
        tScore.GetComponent<Text>().text = score.ToString();
        bScore.GetComponent<Text>().text = BestScore.bestScore.ToString();
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
        if (score > BestScore.bestScore) {
            BestScore.bestScore = score;
            bScore.GetComponent<Text>().text = BestScore.bestScore.ToString();
        }

        tScore.GetComponent<Text>().text = score.ToString();
        if(score%3 == 0) MakingHurdle.faster();
        if (score % 3 == 0) MakingTopHurdle.faster();
    }
    
}
