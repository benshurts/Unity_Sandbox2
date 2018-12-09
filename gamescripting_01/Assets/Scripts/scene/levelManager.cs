using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {


	//ammo
	public int ammo = 10;
	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;
	public GameObject PC2;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;


	//Point Penalty on Death
	public int PointPenaltyOnDeath = 10;

	// Store Gravity Value
	private float GravityStore;

	//end game
	bool GameHasEnded = false;


	public float RestartDelay = 1f;

	[Header("Lives")]
	public static int Lives = 3;
	public int NumOfLives;

	public Image[] LivesArr;
	public Sprite FullLife;
	public Sprite EmptyLife;

	private void Update() {
		//no more lives than num of lives allowed
		if(Lives > NumOfLives) Lives = NumOfLives;
		//life manager
		for(int i = 0; i < LivesArr.Length; i++) {
			//current lives
			if(i < Lives){
				LivesArr[1].sprite = FullLife;
			} else {
				LivesArr[i].sprite = EmptyLife;
			}
			//extra lives
			if(i < NumOfLives){
				LivesArr[i].enabled = true;
			} else {
				LivesArr[i].enabled = false;
			}
		}
		//ammo stuff
		if(ammo < 0) {
			ammo = 0;
		}

	}


	//life removal.
	public static void RemoveLives(int LivesToRemove){
		Lives -= LivesToRemove;
	}

	// Use this for initialization
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	public void GameOver(){
		if(GameHasEnded == false){
			GameHasEnded = true;
			Debug.Log("Game Over!");
			Invoke("Restart",RestartDelay);
		}
	}

	void Restart(){
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reload current scene
		SceneManager.LoadScene("Start_Menu");
	}
	// public IEnumerator EndGame(){

	// }

	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		//Hide PC

		// PC.enabled = false;
		PC2.SetActive(false);
		PC.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
		PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddCoins(-PointPenaltyOnDeath);
		//Debug Message
		Debug.Log ("PC Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match PCs transform position
		PC.transform.position = CurrentCheckPoint.transform.position;
		//Show PC
		// PC.enabled = true;
		PC2.SetActive(true);
		PC.GetComponent<Renderer> ().enabled = true;
		//Spawn PC
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);	}
}
