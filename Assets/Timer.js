#pragma strict

import UnityEngine.UI;

public static var time : float;

function Start () {
	time = 0;
}

function Update () {
	if (GoalArea.goal == false) {
		time += Time.deltaTime;
	}

	var t : int = Mathf.FloorToInt(time);
	var uiText : Text = GetComponent.<Text>();
	uiText.text = "time = " + t.ToString();

}
