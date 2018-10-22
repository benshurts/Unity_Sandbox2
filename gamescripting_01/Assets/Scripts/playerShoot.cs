using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
	//shoot vars
	public Transform FirePoint;
	public GameObject Projectile;
	
	void start() {
		Projectile = GameObject.Find("Bullet1");

	}
	void Update() {
		if(Input.GetKeyUp(KeyCode.Mouse0))
			Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
	}
}
