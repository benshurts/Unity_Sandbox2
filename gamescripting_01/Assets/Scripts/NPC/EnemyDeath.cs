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
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag.Equals("Bullet")) {
			Damage = col.relativeVelocity.magnitude;
			if(Damage > 10) Damage = 10;
			// print("Damage " + Damage);
			if(Damage > 5f){
				TakeDamage(Damage/4);
				// print("health " + Health);
			}
			// print( "Collision 2D Detected. Magnitude: " + col.relativeVelocity.magnitude);
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
