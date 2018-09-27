	using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	//Vars
	public float speed;
	public float jumpForce;
	private float moveInput;

	public GameObject flippedSprites;

	private Rigidbody2D rb;

	//sprite flipping
	private bool facingRight = true;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		moveInput = Input.GetAxisRaw("Horizontal");
	}
	void flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

}