using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	Rigidbody2D rb;
	public int rightVelocity = 2;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (Vector2.right * rightVelocity, ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update () {
		// Control
		if (Input.anyKeyDown) {
			rb.AddForce (Vector2.up * (rightVelocity-rb.velocity.y), ForceMode2D.Impulse);
//			rb.AddForce (Vector2.up * 5, ForceMode2D.Impulse);
		}

		// View
		if (transform.position.y > 1)
			rb.MoveRotation(Mathf.Atan2 (rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
	}
}
