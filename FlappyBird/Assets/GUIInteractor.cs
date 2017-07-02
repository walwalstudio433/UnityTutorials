using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInteractor : MonoBehaviour {

	public GameObject readyPanel, gameOverPanel;
	public int score;
	public Text scoreBoard;

	// Use this for initialization
	void Start () {
		scoreUp (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void scoreUp(int value){
		score += value;
		scoreBoard.text = score.ToString ();
	}

	public void HideReadyPanel ()
	{
		readyPanel.SetActive (false);
	}

	public void ShowGameOverPanel ()
	{
		Invoke ("ShowGameOverPanelInner", 0.5f);

	}

	void ShowGameOverPanelInner ()
	{
		gameOverPanel.SetActive (true);
	}
}