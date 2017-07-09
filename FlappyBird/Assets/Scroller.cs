using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    public float scrollSpeed;
    public GameObject startBackGround;
    public GameObject endBackGround;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 thisPosition;

    // Use this for initialization
    void Start () {
        startPosition = startBackGround.transform.position;
        endPosition = endBackGround.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < endPosition.x-1)
        {
            transform.position = startPosition;
        }
        transform.position = transform.position + (Vector3.right * scrollSpeed);
    }
}
