using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

	public static int Coins;


	TextMeshProUGUI CoinAmt;

	//Init
	void Start() {
		CoinAmt = GetComponent<TextMeshProUGUI>();

		Coins = 0;
	}

	//Step
	void Update() {
		if (Coins < 0) {
			Coins = 0;
		CoinAmt.text = ""+Coins;
		}
	}

	public static void AddPoints (int PointsToAdd) {
		Coins += PointsToAdd;
	}

	//public static void reset

}
