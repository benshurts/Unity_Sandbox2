using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0f;

	public float Damage = 10;

	public LayerMask WhatToHit;

	private float timeToFire = 0f;
	private Transform firePoint;

	private void Awake() {
		firePoint = transform.Find("FirePoint");
		//if no firepoint debug
		if (firePoint == null) {
			Debug.LogError("No Firepoint= WHAT?!"); 
		}
	}
	private void Update() {
		Shoot();
		if(fireRate == 0) {
			if(Input.GetMouseButtonDown(0)) {
				Shoot();
			} else {
				if(Input.GetMouseButton(0) && Time.time > timeToFire) {
					timeToFire = Time.time + 1/fireRate;
					Shoot();
				}
			}
		}
	}

	void Shoot() {
		//creating a vector2 towards mouse position
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		//taking firepoint of tip of gun as vector2
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		//raycast
		RaycastHit2D hit2D = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition,100,WhatToHit);
		//debug with gizmos to see line
		Debug.DrawLine(firePointPosition,(mousePosition-firePointPosition)*100);
		//show collision
		// if(hit.collider != null) {
		// 	Debug.DrawLine(firePointPosition, hit.point, color.red); 
		// }
	}
}
