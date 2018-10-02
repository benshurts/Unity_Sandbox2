	using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	//Vars
	public float speed;
	public float jumpForce;
	private float moveInput;

	//jumping vars
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	public int extraJumps;

	public GameObject flippedSprites;

	private Rigidbody2D rb;

	

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		moveInput = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
	}
	void update() {
		if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0){
			rb.velocity = Vector2.up * jumpForce;
			Debug.Log("jumpForce");
		}
		if(isGrounded == true){
			Debug.Log("Grounded");
		}
	}


}