using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
	Rigidbody2D rb;
	int rightVelocity = 4;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.velocity += Vector2.right*4;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
//			rb.velocity.y = rb.velocity.x;
			rb.velocity += Vector2.up * (rightVelocity-rb.velocity.y);
		}
			
		rb.transform.rotation = Quaternion.AngleAxis (Mathf.Rad2Deg*(Mathf.Atan2(rb.velocity.y, rb.velocity.x)), Vector3.forward);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("@@@");
		Debug.Log("@@@");

	}
}
