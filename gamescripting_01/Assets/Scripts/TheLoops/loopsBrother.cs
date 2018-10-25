using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopsBrother : MonoBehaviour {

public GameObject TheLoops;
public GameObject LoopSpawn;
public Sprite[] LoopSprite;
// public Sprite ChooseLoops;
    // private void Start() {
	// 	GetComponent<SpriteRenderer>().sprite = ChooseLoops;
    // }

	public void Awake() {
		int arrayIdx = Random.Range (0, LoopSprite.Length);
		Sprite ChooseLoops = LoopSprite[arrayIdx];
		GetComponent<SpriteRenderer>().sprite = ChooseLoops;
		Debug.Log(ChooseLoops);
	}

	// public void AllTheLoops() {
	// 	for (int i = 0; i < 5; i++)
	// 	{
	// 		Instantiate(TheLoops, LoopSpawn.position,LoopSpawn.rotation);
	// 	}
	// }
}