using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public float BulletSpeed = 3f;
	float SpeedStartTime = 0f;

	public float FinalShootSpeed;


	void start() {
		// Anim = GetComponent<Animator>();
	}
	void Awake() {
		Anim = GameObject.Find("Shoot").GetComponent<Animator>();

	}
	void Update() {

		Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,RotZ + OffSet);
		ShootDir = difference;
		// print(ShootDir);


		// ShootDirection();
		//holddown for more bullet force
		if(Input.GetMouseButtonDown(0)) {
			SpeedStartTime = Time.time;//time
			// Anim.SetTrigger("IsShooting");
		}
		if(Input.GetMouseButtonUp(0)) {
			float delta = Time.time - SpeedStartTime;//time
			float AdjustedSpeed = BulletSpeed * delta;
			if(AdjustedSpeed > 10f)	{AdjustedSpeed = 10f;}
			//shootspeed
			FinalShootSpeed = AdjustedSpeed - 2;
			print("Final Shoot Speed "+FinalShootSpeed);
			if(FinalShootSpeed > 100) FinalShootSpeed = 100;
			GameObject Bullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
			ShootVel = CalcLaunchVel();
			Anim.SetTrigger("IsShooting");
		}


	}


	public Vector2 CalcLaunchVel(){
		float DispY = Target.position.y - Start.position.y;
		Vector2 DispX = new Vector2 (Target.position.x - Start.position.x, 0);

		Vector2 VelY = Vector2.up * Mathf.Sqrt(-2 * g * h);
		Vector2 VelX = DispX / (Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * DispY - h) / g);

		return VelX + VelY;
	}

}