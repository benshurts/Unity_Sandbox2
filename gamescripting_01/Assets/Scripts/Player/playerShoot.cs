using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
	//shoot vars
	public Transform FirePoint;
	public GameObject Projectile;
	public float OffSet;
	private Animator Anim;

	public float BulletSpeed = 10f;
	float SpeedStartTime = 0f;
	
	public float FinalShootSpeed;

	
	void start() {
		Anim = GetComponent<Animator>();
	}

	void Update() {
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,RotZ + OffSet);
		//holddown for more bullet force
		if(Input.GetMouseButtonDown(0)) {
			SpeedStartTime = Time.time;
		}
		if(Input.GetMouseButtonUp(0)) {
			float delta = Time.time - SpeedStartTime;
			float AdjustedSpeed = BulletSpeed * delta;
			FinalShootSpeed = AdjustedSpeed;
			Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
			Anim.SetTrigger("IsShooting");
		}
	}
}