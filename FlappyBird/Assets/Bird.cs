using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour 
{
	public Background background;
	public Animator animator;
	public Rigidbody2D rigidBody;
	public float jumpPower;
	public float gravityScale;
	public float rotationSpeedForFlying;
	public float rotationSpeedForDying;
	public bool isReady;
	public bool isCollided;
	public bool isJumped;
	public bool isDead;
	public int unitScore;

	public Quaternion deadRotation = Quaternion.Euler (0, 0, -90f);

	public void StartPlay()
	{
		isReady = false;
		background.enabled = true;
		rigidBody.gravityScale = gravityScale;
		GetComponent<GUIInteractor> ().HideReadyPanel ();
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void Update () 
	{


		if (isDead)
			return;

		if (Input.GetMouseButtonDown(0) && isReady) {
			StartPlay ();
			return;
		}

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
		animator.SetTrigger ("onJump");
		rigidBody.velocity = Vector2.zero;
		rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		isJumped = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.StartsWith ("Floor")) {
			CollidedByPillar ();
			DeadByFloor ();
		}

		if (!isCollided && !isDead && other.name.StartsWith ("Pillar")) {
			CollidedByPillar ();
		} 

		if (other.name == "ScoreLine") {
			animator.SetTrigger ("onScored");
			GetComponent<GUIInteractor> ().scoreUp (unitScore);
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
		GetComponent<GUIInteractor> ().ShowGameOverPanel ();
	}
}
