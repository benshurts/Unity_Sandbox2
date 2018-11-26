using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsShootingAnim1 : MonoBehaviour {

	public Animator anim;
	private void Start() {
		anim = GetComponent<Animator>();
	}
	private void Update() {
		if(Input.GetKeyUp(KeyCode.Mouse0)) {
			anim.Play("Shoot");
		}
	}
}
