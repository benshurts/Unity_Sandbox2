using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public float health = 10f;
	public float Damage;
	GameObject Bullet;
	Bullet1 BulletScript;
	private void Update() {

		//death on health 0
		if(health <= 0f) {
			Destroy(gameObject);
		}
		print("health " + health);
	}
	void OnCollisionEnter2D( Collision2D col) {
		if(col.gameObject.tag.Equals("Bullet")) {
			Damage = col.relativeVelocity.magnitude;
			health -= Damage/2;
			Debug.Log( "Collision 2D Detected. Magnitude: " + col.relativeVelocity.magnitude);

		}

	}


}
