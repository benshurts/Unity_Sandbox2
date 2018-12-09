using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {


	//ammo is managed here
	public int ammo = 10;

	public GameObject DeathObj;
	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;
	public GameObject PC2;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;

	private GameObject[] bullets;


	//Point Penalty on Death
	public int PointPenaltyOnDeath = 10;

	// Store Gravity Value
	private float GravityStore;

	//end game
	bool GameHasEnded = false;
	public float RestartDelay = 0.3f;

	[Header("Lives and health")]
	public static int Lives = 3;
	public int NumOfLives = 3;
	public int LivesRemove = 1;
	public Image[] LivesArr;
	public Sprite FullLife;
	public Sprite EmptyLife;
	private void Start() {
		PC = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}
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
		//------------start coroutine respawn-------------
		if(ammo <= -1 && Lives > 0) {
			// StartCoroutine ("RespawnPlayerCo");
			//Invoke("RespawnPlayer",RespawnDelay);
			RespawnPlayer();
		}
		//----------------stop coroutine---------------
		if(ammo > -1){
			// StopCoroutine("RespawnPlayer");
		}
		//---------------game over -------------------
		if(ammo <= -1 && Lives <= 0){
			GameOver();
		}

	}

	//life removal.
	public static void RemoveLives(int LivesToRemove){

		Lives -= LivesToRemove;

		print("Lives"+Lives);
	}

	// Use this for initialization
	public void RespawnPlayer(){
		Instantiate(DeathObj,PC.transform.position,PC.transform.rotation);
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);

		RemoveLives(LivesRemove);
		ammo = 10;
		PC.transform.position = CurrentCheckPoint.transform.position;

		//------------destroy bullets------------
		bullets = GameObject.FindGameObjectsWithTag("Bullet");
		for(var i = 0 ; i < bullets.Length ; i ++)
		{
			Destroy(bullets[i]);
		}
		//StartCoroutine ("RespawnPlayerCo");
	}

	public void GameOver(){
		if(GameHasEnded == false){
			Lives = 3;
			ammo = 10;

			GameHasEnded = true;
			Debug.Log("Game Over!");
			Invoke("Restart",RestartDelay);
		}
	}

	void Restart(){
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reload current scene
		SceneManager.LoadScene("Start_Menu");
		Lives = 3;
		ammo = 10;
	}
	// public IEnumerator EndGame(){

	// }
	/// <summary>
	/// Coroutine for respawning player
	/// </summary>
	/// <returns></returns>
	// public IEnumerator RespawnPlayerCo(){

	// 	//-------------------manage Lives----------------
	// 	RemoveLives(LivesRemove);

	// 	//----------Generate Death Particle-------------------
	// 	// Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);

	// 	//--------Hide PC--------------

	// 	PC2.SetActive(false);
	// 	PC.GetComponent<Renderer> ().enabled = false;
	// 	PC.GetComponent<Rigidbody2D>().isKinematic = true;

	// 	//---------- Gravity Reset-------------
	// 	GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
	// 	PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
	// 	PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

	// 	//---------- Point Penalty--------------
	// 	ScoreManager.AddCoins(-PointPenaltyOnDeath);

	// 	//-----------Debug Message--------------
	// 	Debug.Log ("PC Respawn");

	// 	//-----------------Respawn Delay------------------
	// 	yield return new WaitForSeconds (RespawnDelay);
	// 	print("yeild return");

	// 	//------------------Gravity Restore------------------
	// 	PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;

	// 	//-----------------Match PCs transform position------------------
	// 	PC.transform.position = CurrentCheckPoint.transform.position;

	// 	//-------------------Show PC-----------------------
	// 	PC2.SetActive(true);
	// 	PC.GetComponent<Renderer>().enabled = true;

	// 	//----------------------Spawn PC---------------------------
	// 	PC.GetComponent<Rigidbody2D>().isKinematic = false;
	// 	ammo = 10;

	// 	// Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);

	// 	}
}
