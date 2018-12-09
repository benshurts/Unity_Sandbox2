using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour {

	public int PointsToAdd;
	int Coins;
	ScoreManager ScoreManager;
	private void Start() {
		Physics2D.IgnoreLayerCollision(9,12);

	}

	void OnTriggerEnter2D (Collider2D other){
		Coins = ScoreManager.Coins;
		// Coins = GameObject.Find("CoinsValue").GetComponent<ScoreManager>().Coins;
		if (other.tag == "player") {
			print("touching Bullet");
			Coins += 1;
			Destroy(gameObject);
		}

	}
}
