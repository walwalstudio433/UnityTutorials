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
	public int maxNumOfPipes = 3;

	Queue<GameObject> queue;


	// Use this for initialization
	void Start () {
		queue = new Queue<GameObject> (maxNumOfPipes);
//		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Spawn() {
		yield return new WaitForSeconds (duration);
		StartCoroutine (Spawn ());

		GameObject pipe = dequeueOrCreatePipe ();

		pipe.transform.localPosition = new Vector3 (
			bird.transform.position.x + howFarFromBird,
			Random.Range (minY, maxY),
			0f
		);

	}

	GameObject dequeueOrCreatePipe() {
		GameObject pipe;
		if (queue.Count < maxNumOfPipes) {
			pipe = Instantiate (prefab, transform);
		} else {
			pipe = queue.Dequeue ();
		}

		queue.Enqueue (pipe);

		return pipe;
	}
}
