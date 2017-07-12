using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	public GameObject bird;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bird.transform.position.x - transform.position.x > 9) {
			transform.position += Vector3.right * 9;
		}

	}
}
