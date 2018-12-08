using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShoot : MonoBehaviour {
	float coolDownTImer;
	private void Start() {

	}
	private void Update() {
		coolDownTImer = GameObject.Find("Shooter").GetComponent<playerShoot>().CoolDownTimer;

		if(Input.GetMouseButtonUp(0) && coolDownTImer == 0){
			GetComponent<ParticleSystem>().Emit(10);
		}
	}
}
