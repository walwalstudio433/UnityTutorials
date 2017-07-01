using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
	public Background background;
	public Rigidbody2D rigidBody;
	public float jumpPower;
	public float velocity;
	public float rotateScale;
	public bool isCollided;
	public bool jumped;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
			jumped = true;
			

		if (isCollided) {
			transform.Rotate (0, 0, Time.deltaTime * rotateScale);
		} else {
			transform.localRotation = Quaternion.Euler ((new Vector3 (0, 0, rigidBody.velocity.y * rotateScale)));
		}
	}

	void FixedUpdate()
	{		
		if (jumped) {
			Jump ();
		}

	}

	public void Jump()
	{			
		rigidBody.velocity = Vector2.zero;
		rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		jumped = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Ceiling") {			
			rigidBody.velocity = Vector2.zero;
		} else if (other.name == "Floor") {
			rigidBody.velocity = Vector2.zero;
		} else if (other.name.StartsWith ("pillar")) {
			//isCollided = true;
			//rigidBody.velocity = Vector2.zero;
			//background.Stop();
		}
	}
}
