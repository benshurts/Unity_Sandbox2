using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoMask : MonoBehaviour {

	//ammo life
	// ammoLife = GameObject.Find("levelManager").GetComponent<levelManager>().ammo;
	// public int Ammo = Bullet1.Ammo;
	// public int Ammo = levelManager.ammo;
	// public levelManager Ammo;
	public int Ammo;
	const int MAXAMMO = 10;
	public Sprite CurrentSprite;
	public Sprite SpriteMaskNone;
	public Sprite SpriteMask10;
	public Sprite SpriteMask09;
	public Sprite SpriteMask08;
	public Sprite SpriteMask07;
	public Sprite SpriteMask06;
	public Sprite SpriteMask05;
	public Sprite SpriteMask04;
	public Sprite SpriteMask03;
	public Sprite SpriteMask02;
	public Sprite SpriteMask01;

	public List<Sprite> SpriteList = new List<Sprite>();
	
	void Awake() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
	}

	private void Update() {
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;

		Debug.Log(Ammo + "Mask");
		// string SpriteName = "SpriteMask" + Ammo;
		// if(Ammo == MAXAMMO) GetComponent<SpriteMask>().sprite = SpriteMaskNone;
		// else if(Ammo < MAXAMMO && Ammo > 0) GetComponent<SpriteMask>().sprite = SpriteName; 
		
		
		// switch (Ammo)
		// {

		// 	case 9:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask10;
		// 	break;

		// 	case 8:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask09;
		// 	break;

		// 	case 7:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask08;
		// 	break;

		// 	case 6:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask07;
		// 	break;

		// 	case 5:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask06;
		// 	break;

		// 	case 4:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask05;
		// 	break;

		// 	case 3:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask04;
		// 	break;

		// 	case 2:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask03;
		// 	break;

		// 	case 1:
		// 		GetComponent<SpriteMask>().sprite = SpriteMask02;
		// 	break;

		// 	default:
		// 		GetComponent<SpriteMask>().sprite = SpriteMaskNone;
		// 	break;
		// }
		//check which mask to use
		// CurrentSprite = spriteMask[ammoLife];
		// GetComponent<SpriteMask>().sprite = CurrentSprite;
	}
}
