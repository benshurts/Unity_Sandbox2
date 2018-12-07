using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour {
	private CircleCollider2D cC;
	public int ammo;
	private void Start() {
		ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag.Equals("Player") && Input.GetKeyDown("e")) {
			print("colider");
			ammo += 1;
			Destroy(gameObject);
		}
	}
}
