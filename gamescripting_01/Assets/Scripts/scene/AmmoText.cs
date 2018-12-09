using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoText : MonoBehaviour {

	TextMeshProUGUI AmmoT;

	public int AmmoAmt;
	void Start () {
		AmmoT = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update () {
		AmmoAmt = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
		AmmoT.text = ""+AmmoAmt;
	}
}
