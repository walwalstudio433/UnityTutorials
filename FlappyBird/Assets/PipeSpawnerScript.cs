using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour {

	public GameObject bird;
	public GameObject prefab;
	public int duration = 3;
	public float howFarFromBird = 3;
	public float minY = 0;
	public float maxY = 3;


	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Spawn() {
		yield return new WaitForSeconds (duration);
		GameObject pipe = Instantiate (prefab, transform) as GameObject;
		pipe.transform.localPosition = new Vector3 (
			bird.transform.position.x + howFarFromBird,
			Random.Range (minY, maxY),
			0f
		);
		StartCoroutine(Spawn ());
	}
}
