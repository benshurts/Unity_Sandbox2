using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour {

	//this variable data type is a class or calling a different script
	public levelManager LevelManager;
	public int Ammo;

	// Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType <levelManager>();
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			LevelManager.RespawnPlayer();
		}
		
	}
	
}
