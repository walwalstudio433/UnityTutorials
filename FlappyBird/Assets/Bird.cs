using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	Rigidbody2D rb;
	public int rightVelocity = 2;
	bool alive = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity += Vector2.right * rightVelocity;
	}

	// Update is called once per frame
	void Update () {
		// Control
		if (alive && Input.anyKeyDown) {
			rb.velocity += Vector2.up * (rightVelocity - rb.velocity.y);
		}

		if (rb.velocity.magnitude > .1)
			rb.MoveRotation(Mathf.Atan2 (rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
	}

	void Die() {
		alive = false; // script
		rb.velocity -= Vector2.right * rb.velocity.x;
		GetComponent<AudioSource>().enabled = false;
		GetComponent<Animator>().enabled = false;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Respawn")) {
			go.GetComponent<MonoBehaviour> ().StopAllCoroutines ();
		}
	}
}
