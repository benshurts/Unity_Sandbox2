using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {
	[Header("Unity Stuff")]
	public Image HealthBar;
	private float Health;
	public float StartHealth = 100f;
	public float Damage;
	GameObject Bullet;
	Bullet1 BulletScript;
	private void Start() {
		Health = StartHealth;
	}
	private void Update() {

		//death on health 0
	}
	void OnCollisionEnter2D( Collision2D col) {
		if(col.gameObject.tag.Equals("Bullet")) {
			Damage = col.relativeVelocity.magnitude;
			if(Damage > 5f){
				TakeDamage(Damage/2);
				print("health " + Health);

			}
			print( "Collision 2D Detected. Magnitude: " + col.relativeVelocity.magnitude);

		}

	}
	public void TakeDamage(float ammount){
		Health -= ammount;
		HealthBar.fillAmount = Health / StartHealth;

		if(Health <= 0f) {
			Die();
		}

	}
	public void Die(){
		Destroy(gameObject);
	}


}
