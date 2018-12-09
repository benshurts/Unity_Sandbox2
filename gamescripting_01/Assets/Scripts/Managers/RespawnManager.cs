using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	private static RespawnManager instance;
	public Vector2 lastCheckPoint;
	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else {
			Destroy(gameObject);
		}
	}
}
