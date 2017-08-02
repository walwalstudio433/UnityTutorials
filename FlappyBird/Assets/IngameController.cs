using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum GameState {READY=0, ALIVE, DEAD, GAMEMENU};

public class IngameController : MonoBehaviour {
	public GameObject gameMenuPanel;
	public GameObject gameReadyPanel;
	public GameObject bird;
	public GameObject pipeSpawner;
	public GameObject scoreObject;
	public int score = 0;
	GameState gameState;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		switch (gameState) {
		case GameState.READY:
			if (Input.GetButtonDown ("Fire1")) {
				ActivateAlive ();
			}
			break;
		case GameState.ALIVE:
			if (Input.GetButtonDown ("Cancel")) {
				ActivateGameMenu ();
			}

			if (Input.GetButtonDown ("Fire1")) {
				bird.SendMessage ("Fly");
			}

			break;
		case GameState.DEAD:
			if (Input.GetButtonDown ("Fire1")) {
				if (bird.GetComponent<Rigidbody2D>().velocity.magnitude < .1)
					RestartGame ();
			}
			break;
		case GameState.GAMEMENU:
			if (Input.GetButtonDown ("Cancel")) {
				ActivateAlive ();
			}
			break;
		}

	}

	void ActivateAlive() {
		if (gameState == GameState.ALIVE)
			return;
		gameState = GameState.ALIVE;
		gameMenuPanel.SetActive (false);
		gameReadyPanel.SetActive (false);
		Time.timeScale = 1;

		bird.GetComponent<Rigidbody2D> ().simulated = true;
		pipeSpawner.SendMessage ("Spawn");
	}

	void ActivateDead() {
		if (gameState == GameState.DEAD)
			return;
		gameState = GameState.DEAD;
		bird.SendMessage ("Die");
	}

	void ActivateGameMenu() {
		if (gameState == GameState.GAMEMENU)
			return;
		gameState = GameState.GAMEMENU;
		gameMenuPanel.SetActive (true);
		Time.timeScale = 0;
	}

	void IncrementScore() {
		score++;
		scoreObject.GetComponent<UnityEngine.UI.Text> ().text = score.ToString ();
		bird.SendMessage ("Score");
	}

	void RestartGame ()
	{
		SceneManager.LoadScene ("FlappyBird");
	}

	void QuitGame() {
		Application.Quit ();
	}
}
