using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public float speed;
	// Update is called once per frame
	void Update () {
        this.transform.Translate(-speed, 0, 0);
	}
    private void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
