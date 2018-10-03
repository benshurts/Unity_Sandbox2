using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	private RigidBody2D Player;

	//particles
	public GameObject DeathParticle;
	public GameObject RespawmParticle;

	//Respawn Delay
	public float RespawnDelay;

	//Point Penatly On Death
	public int PointPenaltyOnDeath;

	//store gravity
	private float GravityStore;

	void Start(){
		Player = FindObjectOfType<RigidBody2D>();
	}
	public void RespawnPlayer(){
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//Generate death particle
		Instantiate(DeathParticle, player.transform.position, player.transform.rotation);
		//hide player
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		//gravity reset
		
	}
}
