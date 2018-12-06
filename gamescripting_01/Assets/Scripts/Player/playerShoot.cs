using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
	//shoot vars

	public Transform Start;
	public Transform Target;
	public float h = 25; //height
	public float g = -18; //gravity
//-------------
	public Transform FirePoint;
	public GameObject Projectile;
	public float OffSet;
	private Animator Anim;
	public Vector2 ShootDir;
	public Vector2 ShootVel;
//----------------
	public float BulletSpeed = 10f;
	float SpeedStartTime = 0f;

	public float FinalShootSpeed;


	void start() {
		Anim = GetComponent<Animator>();
	}

	void Update() {

		Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,RotZ + OffSet);
		ShootDir = difference;
		print(ShootDir);


		// ShootDirection();
		//holddown for more bullet force
		if(Input.GetMouseButtonDown(0)) {
			SpeedStartTime = Time.time;
		}
		if(Input.GetMouseButtonUp(0)) {
			// ShootDir = ShootDirection();
			float delta = Time.time - SpeedStartTime;
			float AdjustedSpeed = BulletSpeed * delta;
			FinalShootSpeed = AdjustedSpeed;
			if(FinalShootSpeed > 100) FinalShootSpeed = 100;
			GameObject Bullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
			// Bullet.GetComponent<Rigidbody2D>().AddForce(CalcLaunchVel());
			ShootVel = CalcLaunchVel();
			Anim.SetTrigger("IsShooting");
		}
		// print(FinalShootSpeed);
	}
	public Vector2 CalcLaunchVel(){
		float DispY = Target.position.y - Start.position.y;
		Vector2 DispX = new Vector2 (Target.position.x - Start.position.x, 0);

		Vector2 VelY = Vector2.up * Mathf.Sqrt(-2 * g * h);
		Vector2 VelX = DispX / (Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * DispY - h) / g);

		print(DispX);
		return VelX + VelY;
	}

}