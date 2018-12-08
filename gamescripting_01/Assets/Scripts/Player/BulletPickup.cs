using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour {
	private CircleCollider2D cC;
	public int ammo;
	bool CanPickup = false;
	float TimeToPickup = 1f;
	private void Start() {
		// ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;

	}
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag.Equals("Player")) {
			ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo += 1;
			Destroy(gameObject);
		}
	}

}
