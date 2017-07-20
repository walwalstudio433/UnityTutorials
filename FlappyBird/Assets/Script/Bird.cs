using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("#: " + transform.rotation.z);
        if (Input.GetButton("Jump"))
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
            if (transform.rotation.z < 0.08) { 
                transform.Rotate(new Vector3(0,0,1.5f));
            }
        }
        else if (transform.rotation.z > -0.03)
        {
            transform.Rotate(new Vector3(0, 0, -0.4f));
        }




    }
}
