using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLeft : MonoBehaviour
{
    public Text tScore;
    public int score;
    // Use this for initialization
    void Start()
    {
        score = 0;
        tScore.GetComponent<Text>().text = "SCORE : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collider");
        Destroy(other.gameObject);
        score++;
        tScore.GetComponent<Text>().text = "SCORE : " + score.ToString();
    }
    
}
