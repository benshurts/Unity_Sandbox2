using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
	//shoot vars
	public Transform FirePoint;
	public GameObject Projectile;
	public Sprite[] normalBullets;

	//private float variable = 2f;

	//GameObject BulletPrefab = Resources.Load("Bullet1") as GameObject;
	
	void start() {
		Projectile = GameObject.Find("Bullet1");
		//GameObject BulletPrefab = Resources.Load("Bullet1") as GameObject;
	}

	// private void Awake() {
	// 	int arrayIdx = Random.Range(0, normalBullets.Length);
	// 	Sprite chooseBulletSprite = normalBullets[arrayIdx];
	// 	GetComponent<SpriteRenderer>().sprite = chooseBulletSprite;
	// }
	void Update() {
		if(Input.GetKeyUp(KeyCode.Mouse0))
			
			Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
	}

	//  void Shoot()
	// {
	// 	Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	// 	aimPos.z = 0;
	
	// 	//Creating the bullet and shooting it
	// 	var pel = Instantiate(Bullet, Spawn.position, Spawn.rotation);
	// 	pel.GetComponent<Rigidbody2D>().AddForce(aimPos.normalized * 8000f);
	// 	//Playing the bullet noise
	// 	Shot.Play();
	// 	//shooting and reloading
	// 	usingBulletPerMag -= 1;
	// }
}