using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSpawn : MonoBehaviour {

//public GameObject Loops;
public Transform CreateLoops;

// public float TimeSpeed = 1f;
// public float TimeLeft = 8f;
private bool Spawner;
	private void Start() {
		GameObject prefab = Resources.Load ("TheLoops") as GameObject;

		SpawnTimer();
		
		while(Spawner == true)
		{	
			GameObject go = Instantiate(prefab, CreateLoops.position, CreateLoops.rotation);
			//go.transform.position = new Vector3(0, 0, 0);
			Spawner = false;
		}
	}

	IEnumerator SpawnTimer() {
		yield return new WaitForSeconds(2);
		Spawner = true;
	}

	void Rainbow() {
		for (int i = 0; i < 5; i++)
		{
			//GetComponent<SpriteRenderer>().color
		}
	}
}
