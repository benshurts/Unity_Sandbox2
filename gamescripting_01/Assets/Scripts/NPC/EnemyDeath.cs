﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Bullet")) {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
