using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject bird;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += (bird.transform.position-transform.position).x * Vector3.right;

//		Debug.Log (bird.transform.position);
	}
}
