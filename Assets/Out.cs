using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Out : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Main");
		}
	}
}
