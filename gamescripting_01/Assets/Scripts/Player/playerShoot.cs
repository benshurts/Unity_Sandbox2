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

	public float CoolDown = 5f;
	public float CoolDownTimer;


//-------------
	public Transform FirePoint;
	public GameObject Projectile;
	public float OffSet;
	private Animator Anim;
	public Vector2 ShootDir;
	public Vector2 ShootVel;
//----------------
	public float BulletSpeed = 0f;
	float SpeedStartTime = 0f;

	public float FinalShootSpeed;

	//camera shaker
	private CameraShake CameraShake;

	void start() {
		CameraShake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();
		// Anim = GetComponent<Animator>();
		// CameraShaker = GameObject.Find("Camera").GetComponent<CameraShaker>();
		// StartCoroutine(CameraShaker.Shake(0.5f, 0.4f));

	}
	void Awake() {
		Anim = GameObject.Find("Shoot").GetComponent<Animator>();
		// CameraShaker = GameObject.Find("MainCamera").GetComponent<CameraShaker>();

	}
	void Update() {

		Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,RotZ + OffSet);
		ShootDir = difference;
		// print(ShootDir);
		// cooldown timer
		if(CoolDownTimer < 0) CoolDownTimer = 0;
		if(CoolDownTimer > 0) CoolDownTimer -= Time.deltaTime*5;


		//holddown for more bullet force
		if(Input.GetMouseButtonDown(0) && CoolDownTimer == 0) {
			FinalShootSpeed = BulletSpeed;
			SpeedStartTime = Time.time;//time
			// print("Start time " + SpeedStartTime);

		}
		if(Input.GetMouseButtonUp(0) && CoolDownTimer == 0) {
			//camera shake
			// StartCoroutine(CameraShaker.Shake(0.5f, 0.4f));

			float delta = Time.time - SpeedStartTime;//time
			if(delta > 1f) delta = 1f;
			//float NewTime = Time.time;
			//float delta = Mathf.Lerp(SpeedStartTime, NewTime, 0.05f);
			// print("time dif " + delta);
			// float AdjustedSpeed = BulletSpeed * delta;
			float AdjustedSpeed = BulletSpeed * delta;
			//if(AdjustedSpeed > 10f)	{AdjustedSpeed = 10f;}
			//shootspeed
			FinalShootSpeed = Mathf.Lerp(delta,AdjustedSpeed,0.5f);
			// FinalShootSpeed = AdjustedSpeed;
			// print("Final Shoot Speed "+FinalShootSpeed);
			// if(FinalShootSpeed > 10) FinalShootSpeed = 10;
			GameObject Bullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
			ShootVel = CalcLaunchVel();
			Anim.SetTrigger("IsShooting");
			CoolDownTimer = CoolDown;

			//particles and camera shake
			//ParticleSystem RockParticles = Instantiate(SpawnParticle,FirePoint.position,FirePoint.rotation);
			// StartCoroutine(CameraShaker.Shake(0.5f, 0.4f));

		}
		// print("cooldown " +CoolDownTimer);

	}


	public Vector2 CalcLaunchVel(){
		float DispY = Target.position.y - Start.position.y;
		Vector2 DispX = new Vector2 (Target.position.x - Start.position.x, 0);

		Vector2 VelY = Vector2.up * Mathf.Sqrt(-2 * g * h);
		Vector2 VelX = DispX / (Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * DispY - h) / g);

		return VelX + VelY;
	}

}