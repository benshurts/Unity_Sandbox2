using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
	//shoot vars
	public Transform FirePoint;
	public GameObject Projectile;
	public Sprite[] normalBullets;

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
}
