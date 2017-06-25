using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
	public Rigidbody2D rigidBody;
	public float jumpPower;
	public float anumationSpeed;

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
		rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
	}

	void FixedUpdate()
	{
		if ((-2 <= transform.position.y && transform.position.y <= 2) && Input.GetMouseButtonDown (0)) 
			Jump ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Ceiling" || other.name == "Floor") 
		{
			Debug.Log (other.name);
			rigidBody.velocity = Vector2.zero;
		}
	}
}
