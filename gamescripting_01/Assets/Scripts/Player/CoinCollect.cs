using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour {

	public int CoinValue = 1;
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			ScoreManager.AddCoins(CoinValue);
			Destroy(gameObject);
		}

	}
}
