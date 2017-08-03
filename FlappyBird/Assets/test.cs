using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	// Use this for initialization
	void Start () {
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
        

    }
}
