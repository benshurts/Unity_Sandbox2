using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpriteFlip : MonoBehaviour {

	private bool facingRight = true;

	private float moveInput;

	void FixedUpdate() {
		moveInput = Input.GetAxisRaw("Horizontal");
		if(facingRight == false && moveInput > 0){
			flip();
		} else if(facingRight == true && moveInput < 0) {
			flip();
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 Scalar = transform.localScale;
		Scalar.x *= -1;
		transform.localScale = Scalar;
	}
}
