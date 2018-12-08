using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

	public int Ammo;

	//init force
	public Vector2 Impulse;
	//-----------------
	//if bullet hits enemy
	public GameObject EnemyDeath;

	//if bullet hits wall
	public GameObject ProjectileParticle;

	//add points...
	public int PointsForKill;

	//bullet sprite stuff
	public Sprite[] normalBullets;

	public float ShootSpeed;//pass this to change damage of rock.
	Vector2 ShootDirection;
	Vector2 ShootVector;
	Vector2 ShootVelocity;
	playerShoot playerShoot;
	private void Awake() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo -= 1;
		ShootSpeed = GameObject.Find("Shooter").GetComponent<playerShoot>().FinalShootSpeed;
		ShootDirection = GameObject.Find("Shooter").GetComponent<playerShoot>().ShootDir;
		ShootVelocity = GameObject.Find("Shooter").GetComponent<playerShoot>().ShootVel;
		playerShoot = GameObject.Find("Shooter").GetComponent<playerShoot>();
		//get dir vector2
		Impulse = new Vector2(1,1);
	}


	void Start() {

		ShootVector = playerShoot.CalcLaunchVel();
		//get random sprite for bullet
		int arrayIdx = Random.Range(0, normalBullets.Length);
		Sprite chooseBulletSprite = normalBullets[arrayIdx];
		GetComponent<SpriteRenderer>().sprite = chooseBulletSprite;
		//force passed in
		GetComponent<Rigidbody2D>().AddForce(ShootDirection * ShootSpeed, ForceMode2D.Impulse);
		// print(ShootDirection*ShootSpeed);
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
		Instantiate(ProjectileParticle, transform.position, transform.rotation);
	}



}
