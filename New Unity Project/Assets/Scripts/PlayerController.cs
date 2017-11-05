﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Animator Anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Anim.SetFloat("Speed", Input.GetAxis("Vertical"));
		Anim.SetBool("Running", Input.GetKeyDown(KeyCode.LeftShift));
	}
}
