using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
	private RespawnManager respawnManager;
	private void Start() {
		respawnManager = GameObject.FindGameObjectWithTag("RM").GetComponent<RespawnManager>();
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			// respawnManager.lastCheckPointPos = transform.position;
		}
	}
}
