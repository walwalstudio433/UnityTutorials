using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
	public Background background;
	public Animator animator;
	public Rigidbody2D rigidBody;
	public float jumpPower;
	public float rotationSpeedForFlying;
	public float rotationSpeedForDying;
	public bool isCollided;
	public bool isJumped;
	public bool isDead;


	public Quaternion deadRotation = Quaternion.Euler (0, 0, -90f);

	void Update () 
	{
		if (isDead)
			return;

		if (Input.GetMouseButtonDown (0) && !isCollided) 
			isJumped = true;
			
		if (isCollided) {
			DyingAction ();
		} else {
			FlyingAction ();
		}
	}

	void DyingAction ()
	{		
		if (!Mathf.Approximately (transform.localRotation.z, deadRotation.z))
			transform.localRotation = Quaternion.Slerp (transform.localRotation, deadRotation, Time.deltaTime * rotationSpeedForDying);
	}

	void FlyingAction ()
	{
		float rotationZofVelocity = rigidBody.velocity.y * rotationSpeedForFlying;
		transform.localRotation = Quaternion.Euler (0, 0, rotationZofVelocity);
	}

	void FixedUpdate()
	{		
		if (isJumped) {
			Jump ();
		}
	}

	public void Jump()
	{			
		rigidBody.velocity = Vector2.zero;
		rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		isJumped = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Floor") {
			CollidedByPillar ();
			DeadByFloor ();
		}

		if (!isCollided && !isDead && other.name.StartsWith ("pillar")) {
			CollidedByPillar ();
		} 
	}

	void CollidedByPillar ()
	{
		isCollided = true;
		animator.SetBool ("isCollided", true);
		rigidBody.velocity = Vector2.zero;
		background.Stop ();
	}

	void DeadByFloor()
	{
		isDead = true;
		animator.SetBool ("isDead", true);
		transform.localRotation = deadRotation;
		rigidBody.gravityScale = 0;
	}
}
