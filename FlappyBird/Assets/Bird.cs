using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
	public Rigidbody2D rigidBody;
	public float jumpPower;
	public float maxVelocity;
	public float velocity;
	public float gravityScale;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Jump()
	{			
		if (transform.position.y >= 1.5f)
			return;

		if ((rigidBody.constraints & RigidbodyConstraints2D.FreezePositionY) != 0)
			rigidBody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
			
		rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
	}

	void FixedUpdate()
	{		
		if (Input.GetMouseButtonDown (0)) 
			Jump ();

		float velocity = Mathf.Min (maxVelocity, rigidBody.velocity.y);
		SetBirdVelocity (velocity);
		velocity = rigidBody.velocity.y;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Ceiling") {			
			rigidBody.velocity = Vector2.zero;
			SetBirdPosition (1.5f);
		}else if(other.name == "Floor") {
			rigidBody.velocity = Vector2.zero;
			SetBirdPosition (-1.5f);
			rigidBody.constraints |= RigidbodyConstraints2D.FreezePositionY;
		}
	}

	void SetBirdVelocity(float y)
	{
		rigidBody.velocity = new Vector2 (0, y);
	}

	void SetBirdPosition(float y)
	{
		transform.position = new Vector2 (0, y);
	}
}
