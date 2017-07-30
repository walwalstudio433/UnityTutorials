using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public int rightVelocity = 2;
	public AudioClip flyAudioClip, deathAudioClip, scoreAudioClip;
	public GameObject scoreObject;

	Rigidbody2D rb;
	AudioSource audioSource;
	bool isAlive = true;
	int score = 0;

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

	// Update is called once per frame
	void Update () {
		if (!isAlive)
			return;

		if (Input.GetButtonDown ("Cancel")) {
			
		} else if (Input.GetButtonDown ("Fire1")) {
			Fly ();
		}
	}

	void Fly() {
		// velocity.y = velocity.x
		rb.velocity += Vector2.up * (rightVelocity - rb.velocity.y);

		// play sound
		audioSource.PlayOneShot(flyAudioClip);
	}

	void Score() {
		score++;
		audioSource.PlayOneShot (scoreAudioClip);
		Debug.Log ("Score" + score);
		scoreObject.GetComponent<UnityEngine.UI.Text> ().text = System.String.Format("{0}", score);
	}

	void Die() {
		if (!isAlive) return;

		// block script in Update()
		isAlive = false;

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
