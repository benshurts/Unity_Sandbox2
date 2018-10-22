using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

	public float Speed;
	public Rigidbody2D Player;

	//if bullet hits enemy
	public GameObject EnemyDeath;

	//if bullet hits wall
	public GameObject ProjectileParticle;

	//add points...
	public int PointsForKill;

	void Start() {

		if(Player.transform.localScale.x < 0) {
			Speed = -Speed;
		}
	}

	void Update() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTrigger2D(Collider2D other) {
		if (other.tag == "enemy") {
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints(PointsForKill);
		}

		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy(gameObject);
	}


}
