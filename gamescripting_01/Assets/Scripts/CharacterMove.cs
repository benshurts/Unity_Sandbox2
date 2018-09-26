﻿using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	//vars
	public float speed;
	public float jumpForce;
	private float moveInput;

	private Rigidbody2D rb;

	//jumping
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	//extra jumps
	private int extraJumps;
	public int extraJumpsValue;
	private bool facingRight = true;

	void Start() {
		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D>();

	}

	void FixedUpdate() {
		moveInput = Input.GetAxisRaw("Horizontal");

		rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

		if(facingRight == false && moveInput > 0) {
			flip();
		} else if(facingRight == true && moveInput < 0) {
			flip();
		}
	}
	void Update() {
		if(isGrounded == true) {
			extraJumps = extraJumpsValue;
		}

		if(Input.GetKeyDown(KeyCode.Space) && extraJumps < 0) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
	}
}
