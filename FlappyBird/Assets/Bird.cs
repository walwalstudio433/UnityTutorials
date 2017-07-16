using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }

        
	}
}
