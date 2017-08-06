using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
    // Use this for initialization
    public Text bScore;

    void Start () {
        bScore.GetComponent<Text>().text = PlayerPrefs.GetInt("bestScore").ToString();

    }

    void Awake()
    {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            Application.LoadLevel("FlappyBird");

        }
        else if (Input.GetButton("Reset"))
        {
            PlayerPrefs.SetInt("bestScore", 0);

        }
    }
}
