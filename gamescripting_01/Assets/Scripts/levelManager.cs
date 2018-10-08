using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D Player;

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
		// Player = FindObjectOfType<RigidBody2D>();
	}
	public void RespawnPlayer(){
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//Generate death particle
		Instantiate(DeathParticle, Player.transform.position, Player.transform.rotation);
		//hide player
			//player.enabled = false;
		Player.GetComponent<Renderer>().enabled = false;
		//gravity reset
		GravityStore = Player.GetComponent<Rigidbody2D>().gravityScale;
		Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//point penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Message
		Debug.Log ("Player Respawen");
		//respawn delay
		yield return new WaitForSeconds (RespawnDelay);
		//gravity restore
		Player.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//match players transform position
		Player.transform.position = CurrentCheckPoint.transform.position;
		//show player
		Player.GetComponent<Renderer>().enabled = true;
		//spawn particle
		Instantiate(RespawmParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.position);

	}
}
