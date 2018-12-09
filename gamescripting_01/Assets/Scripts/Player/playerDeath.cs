using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour {

	//this variable data type is a class or calling a different script
	public levelManager LevelManager;
	public playerShoot PlayerShoot;
	public int Ammo;
	public ParticleSystem SlimeParticle;

	private CameraShake CameraShake;

	float damageTimer;


	// Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType <levelManager>();
		CameraShake = GameObject.FindGameObjectWithTag("Shake").GetComponent<CameraShake>();

	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo -= 1;
			Instantiate(SlimeParticle, transform.position, other.transform.rotation);
			CameraShake.CamShake();


		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		// if(other.gameObject.CompareTag("Player")){
		// 	print("colide");
		// 	Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo -= 1;

		// 	// LevelManager.RespawnPlayer();
		// }

	}
	void DamagePlayer(){
		
		CameraShake.CamShake();

	}
	// public IEnumerator DoDamageCo(){

	// }
	private void Update() {
		
	}

}
