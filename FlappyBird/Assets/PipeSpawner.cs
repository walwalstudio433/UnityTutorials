using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    public int SpawnRateMax;
    public int SpawnRateMin;
    public int MiniHeight;
    public int MaxHeight;
    public GameObject pipe;

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(SpawnRateMin, SpawnRateMax));

        Instantiate(pipe, new Vector3(this.transform.position.x, Random.Range(MiniHeight, MaxHeight), this.transform.position.z), this.transform.rotation);

        StartCoroutine("Spawn");
    }
}
