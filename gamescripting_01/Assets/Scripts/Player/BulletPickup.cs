using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour {
	private CircleCollider2D cC;
	public int ammo;
	bool CanPickup = false;
	float TimeToPickup = 1f;
	private void Start() {
		ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Player") && TimeToPickup == 0) {
			CanPickup = true;
			print("Press E to pick up");
		}
	}
	private void Update() {
		TimeToPickup -= Time.deltaTime/2;
		if (TimeToPickup < 0) TimeToPickup = 0;
		// print(TimeToPickup);
		if(CanPickup){
			if(Input.GetKeyUp("e"))
			print("pickup");
			ammo += 1;
			// Destroy(gameObject);
		}

	}
}
