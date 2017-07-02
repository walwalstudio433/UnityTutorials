using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInteractor : MonoBehaviour {

	public GameObject readyPanel, gameOverPanel;
	public int score;
	public Text scoreText, scoreTextInScoreBoard, bestTextInScoreBoard;
	public Image medal;
	public int goldCut, silverCut, bronzeCut;
	public Sprite goldMedal, silverMedal, bronzeMedal;

	// Use this for initialization
	void Start () {
		scoreUp (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void scoreUp(int value){
		score += value;
		scoreText.text = score.ToString ();
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
		if (score >= goldCut) {
			medal.sprite = goldMedal;
		} else if (score >= silverCut) {
			medal.sprite = silverMedal;
		} else if (score >= bronzeCut) {
			medal.sprite = bronzeMedal;
		} else {
			medal.enabled = false;
		}

		scoreTextInScoreBoard.text = score.ToString ();
		gameOverPanel.SetActive (true);
	}
}