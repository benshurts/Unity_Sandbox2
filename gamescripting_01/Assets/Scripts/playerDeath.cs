﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour {

	//this variable data type is a class or calling a different script
	public levelManager LevelManager;

	// Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType <levelManager>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			LevelManager.RespawnPlayer();
		}
		
}
}
