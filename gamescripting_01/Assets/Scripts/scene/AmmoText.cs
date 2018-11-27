using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoText : MonoBehaviour {

	Text AmmoT;
	public int AmmoAmt;
	void Start () {		
		AmmoT = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		AmmoAmt = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
		AmmoT.text = "Ammo " + AmmoAmt;
	}
}
