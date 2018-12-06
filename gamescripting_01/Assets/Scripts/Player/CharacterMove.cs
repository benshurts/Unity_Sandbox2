using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	// Player Movement Variables
	public int MoveSpeed;
	private float JumpHeight;

	int Ammo;
	int AmmoNum;

	//Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	public BoxCollider2D PlayerCollider;


	// Use this for initialization
	void Start () {

	}


	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		// This code makes the character jump
		Ammo = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;
		AmmoNum = GameObject.Find("GameManager").GetComponent<levelManager>().ammo;

		//jump higher the less ammo you have



		if(Ammo > 0) {
			switch (Ammo) {

				case 10:
					JumpHeight = 5f;
					break;

				case 9:
					JumpHeight = 5.5f;
					break;

				case 8:
					JumpHeight = 6f;
					break;

				case 7:
					JumpHeight = 6.5f;
					break;

				case 6:
					JumpHeight = 7f;
					break;

				case 5:
					JumpHeight = 7.5f;
					PlayerCollider.size = new Vector2(1, 0.5f);
					PlayerCollider.offset = new Vector2(0, -0.25f);
					break;

				case 4:
					JumpHeight = 8f;
					break;

				case 3:
					JumpHeight = 8.5f;
					break;

				case 2:
					JumpHeight = 9f;
					break;

				case 1:
					JumpHeight = 10f;
					break;

				default:
					JumpHeight = 10f;
					break;
			}
		}
	// Debug.Log("JumpHeight " + JumpHeight);

		if(Input.GetKeyDown (KeyCode.Space)&& grounded){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		}

		// This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);


		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

		}
	}
}