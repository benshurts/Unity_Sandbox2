using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoMask : MonoBehaviour {

	//ammo life
	public int ammoLife;
	public Sprite CurrentSprite;
	public Sprite[] spriteMask;
	private void Start() {
		ammoLife = GameObject.Find("levelManager").GetComponent<levelManager>().ammo;
	}
	private void Update() {

		//check which mask to use
		CurrentSprite = spriteMask[ammoLife];
		GetComponent<SpriteMask>().sprite = CurrentSprite;
	}
}
