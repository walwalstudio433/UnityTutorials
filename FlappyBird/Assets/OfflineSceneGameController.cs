using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class OfflineSceneGameController : MonoBehaviour {
	public Button joinButton;
	public SceneAsset onlineScene;

	// Use this for initialization
	void Start () {
		NetworkManager.On("error", delegate {
			joinButton.interactable = false;
		});
		NetworkManager.On ("connect", delegate {
			joinButton.interactable = true;

		});
	}

	public void Join() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (onlineScene.name);
	}
}
