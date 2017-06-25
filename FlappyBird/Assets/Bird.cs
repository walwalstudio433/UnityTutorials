using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }
	}

    public void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
