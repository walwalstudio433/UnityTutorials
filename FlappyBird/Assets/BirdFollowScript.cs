using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollowScript : MonoBehaviour {
	public int distance=9;
	public GameObject bird;

	void Start () {
	}
	
	void Update () {
		if (bird.transform.position.x - transform.position.x > distance) {
			transform.position += Vector3.right * distance;
		}
	}
}
