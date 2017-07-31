using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
	public int rightVelocity = 2;
	public AudioClip flyAudioClip, deathAudioClip, scoreAudioClip;

	Rigidbody2D rb;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		rb.velocity += Vector2.right * rightVelocity;
	}

	void FixedUpdate () {
		// Rotation follows the velocity.
		if (rb.velocity.magnitude > .1)
			rb.MoveRotation(Mathf.Atan2 (rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
		
	}

	public void Fly() {
		// velocity.y = velocity.x
		rb.velocity += Vector2.up * (rightVelocity - rb.velocity.y);

		// play sound
		audioSource.PlayOneShot(flyAudioClip);
	}

	void Score() {
		audioSource.PlayOneShot (scoreAudioClip);
	}

	void Die() {
		// velocity.x = 0
		rb.velocity -= Vector2.right * rb.velocity.x;

		// stop animation
		GetComponent<Animator>().enabled = false;

		// stop respawn.
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Respawn")) {
			go.GetComponent<MonoBehaviour> ().StopAllCoroutines ();
		}

		// play sound
		audioSource.PlayOneShot (deathAudioClip);
	}
}
