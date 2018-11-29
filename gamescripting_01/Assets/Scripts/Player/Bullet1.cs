using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

	public int Ammo;
	public float Speed;
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
	private void Awake() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo -= 1;
		ShootSpeed = GameObject.Find("Shooter").GetComponent<playerShoot>().FinalShootSpeed;
	}


	void Start() {
		
		//get random sprite for bullet
		int arrayIdx = Random.Range(0, normalBullets.Length);
		Sprite chooseBulletSprite = normalBullets[arrayIdx];
		GetComponent<SpriteRenderer>().sprite = chooseBulletSprite;
		
		//get mouse position
		// Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		// float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		// transform.rotation = Quaternion.Euler(0f,0f,RotZ + OffSet);


		// if(Player.transform.localScale.x > 0) {
		// 	Speed = -Speed;
		// }
	}


	void Update() {
		// Debug.DrawRay(transform.position,Vector2.up,Color.red, 0.5f);
		
		//transform.Translate(transform.up * ShootSpeed * Time.deltaTime);
		GetComponent<Rigidbody2D>().AddForce(transform.up * ShootSpeed * Time.deltaTime);
		
		// GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
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
