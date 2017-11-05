using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBirdScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			SendMessageUpwards ("ActivateDead");
		} else if (coll.gameObject.tag == "OtherBird") {
			coll.gameObject.SendMessage ("Die");
		}
	}
}
