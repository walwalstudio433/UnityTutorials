#pragma strict

public static var goal: boolean;

function Start () {
	goal = false;
}

function OnTriggerEnter (col: Collider) {
	if (col.gameObject.tag == "Player") {
		goal = true;
	}
}