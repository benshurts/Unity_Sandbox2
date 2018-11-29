using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

	public int Ammo;
	public float Speed;

	//init force
	public Vector2 Impulse;
	bool m_oneTime = false;
	//-----------------
	public Rigidbody2D Player;

	//if bullet hits enemy
	public GameObject EnemyDeath;

	//if bullet hits wall
	public GameObject ProjectileParticle;

	//add points...
	public int PointsForKill;

	//bullet sprite stuff
	public Sprite[] normalBullets;

	private Vector2 MousePosition;
	
	public float OffSet;

	float ShootSpeed;
	Vector2 ShootDirection;
	private void Awake() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo -= 1;
		ShootSpeed = GameObject.Find("Shooter").GetComponent<playerShoot>().FinalShootSpeed;
		ShootDirection = GameObject.Find("Shooter").GetComponent<playerShoot>().ShootDir;

		//get dir vector2
		Impulse = new Vector2(1,1);
	}


	void Start() {
		
		
		//get random sprite for bullet
		int arrayIdx = Random.Range(0, normalBullets.Length);
		Sprite chooseBulletSprite = normalBullets[arrayIdx];
		GetComponent<SpriteRenderer>().sprite = chooseBulletSprite;
		
	}


	void FixedUpdate() {

		if (!m_oneTime)
        {
			GetComponent<Rigidbody>().AddForce(Impulse, ForceMode.Impulse);//use forcemode.impulse for different masses .velocitychange to ignore different masses
			m_oneTime = false;
        }

	}

	void OnTrigger2D(Collider2D other) {
		if (other.tag == "enemy") {
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints(PointsForKill);
			
		}
		if (other.tag == "player") {
			print("touching Bullet");
			Ammo += 1;
			Destroy(gameObject);
		}

		// Instantiate(ProjectileParticle, transform.position, transform.rotation);
		// Destroy(gameObject);
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		// Instantiate(ProjectileParticle, transform.position, transform.rotation);
		// Destroy (gameObject);
	}


}
