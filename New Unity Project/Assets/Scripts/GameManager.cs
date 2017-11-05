using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public List<Character> Characters = new List<Character>();
	List<string> names = new List<string>();
	bool ShowCharWheel;
	public int SelectedCharacter;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		foreach (Character c in Characters) {
			c.Instance = Instantiate(c.PlayerPrefab, c.HomeSpawn.position, c.HomeSpawn.rotation);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.C)) {
			ShowCharWheel = true;
		} else {
			ShowCharWheel = false;
		}

		Camera.main.GetComponent<SmoothFollow>().target = Characters[SelectedCharacter].PlayerPrefab;
	}

	void OnGUI() {
		if (ShowCharWheel) {
			GUILayout.BeginArea(new Rect(Screen.width - 256, Screen.height - 256, 256, 256), GUIContent.none,  "box");
			foreach (Character c in Characters) {
				if (GUILayout.Button(c.Icon, GUILayout.Width(64), GUILayout.Height(64))) {
					SelectedCharacter = Characters.IndexOf(c);
				}
			}
			GUILayout.EndArea();
		}
	}
}

[System.Serializable]
public class Character {
	public string Name;
	public Texture2D Icon;
	public GameObject PlayerPrefab;

	public GameObject Instance;
	public Transform HomeSpawn;
}

