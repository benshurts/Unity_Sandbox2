using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0f;

	public float Damage = 10;

	public LayerMask notToHit;

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
		if(fireRate == 0) {
			if(Input.GetMouseButtonDown(0)) {
				Shoot();
			} else {
				if(Input.GetMouseButton(0)) && Time.time > timeToFire {
					timeToFire = Time.time + 1/fireRate;
					Shoot();
				}
			}
		}
	}
}
