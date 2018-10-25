using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSpawn : MonoBehaviour {

//public GameObject Loops;
public GameObject CreateLoops;
	private void Start() {
		GameObject prefab = Resources.Load ("TheLoops") as GameObject;
		
		for (int i = 0; i < 8; i++)
		{	
			GameObject go = Instantiate(prefab);
			//go.transform.position = new Vector3(0, 0, 0);
		}
	}
}
