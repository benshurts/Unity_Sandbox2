using System.Collections.Generic;
using UnityEngine;

public class ammoMask : MonoBehaviour {

	public int Ammo;
	const int MAXAMMO = 10;
	public Sprite SpriteMaskNone;
	public Sprite DeathSprite;
	public List<Sprite> SpriteList = new List<Sprite>();

	void Awake() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
	}

	private void Update() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
		// Debug.Log(Ammo + "Mask");
		if(Ammo == MAXAMMO) GetComponent<SpriteMask>().sprite = SpriteMaskNone;
		else  GetComponent<SpriteMask>().sprite = SpriteList[Ammo];
	}
}
