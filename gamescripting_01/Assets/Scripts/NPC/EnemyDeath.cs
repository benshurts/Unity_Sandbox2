using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public float health = 10f;
	GameObject Bullet;
	Bullet1 BulletScript;
	private void Update() {
		if(health == 0f) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision2D col) {
		Vector3 collisionForce = col.impulse / Time.fixedDeltaTime;
		if(col.gameObject.tag.Equals("Bullet")) {
			// BulletScript.ShootSpeed
			Destroy(col.gameObject);
		}

	}


}
