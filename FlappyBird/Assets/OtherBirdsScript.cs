using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBirdsScript : MonoBehaviour {
	public GameObject birdPrefab;
	public GameObject mainBird;
	private Dictionary <string, GameObject> birdDictionary;
	// Use this for initialization
	void Start () {
		birdDictionary = new Dictionary<string, GameObject> ();
		NetworkManager.On ("Fly", delegate(JSONObject obj) {
			string birdId = ""; obj.GetField(ref birdId, "birdId");
			GameObject bird = FindOrCreateBird(birdId);
			bird.transform.position = JsonUtility.FromJson<Vector3>(obj.GetField("position").ToString());
			bird.SendMessage("Fly");
			Debug.Log(bird);
			bird.GetComponent<BirdScript>().Fly();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	GameObject FindOrCreateBird(string id) {
		GameObject bird;
		if (!birdDictionary.ContainsKey (id)) {
			bird = Instantiate (birdPrefab, transform);
			Physics2D.IgnoreCollision (bird.GetComponent<Collider2D>(), mainBird.GetComponent<Collider2D>());
			birdDictionary.Add (id, bird);
		}

		birdDictionary.TryGetValue (id, out bird);
		return bird;
	}
}
