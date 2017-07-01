using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInteractor : MonoBehaviour {

	public int score;
	public Text scoreBorad;

	// Use this for initialization
	void Start () {
		scoreUp (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void scoreUp(int value){
		score += value;
		scoreBorad.text = score.ToString ();
	}
}