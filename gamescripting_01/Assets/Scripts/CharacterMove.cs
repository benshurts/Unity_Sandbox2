using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	// Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool DoubleJump;

	//Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//non-stick player
	private float MoveVelocity;

	//Sprite Flipper
	private SpriteRenderer MySpriteRenderer;
	
	//awake
	void Awake() {
		//get ref to sprite renderer comp on this obj
		MySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
	
	}
	

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		//sprite flipping
		//if var isn't empty
		if(MySpriteRenderer != null) {
			//Press A key
			if(Input.GetKeyDown(KeyCode.A)) {
				//flip sprite
				MySpriteRenderer.flipX = true;
			}
			if(Input.GetKeyDown(KeyCode.D))
            {
                // flip the sprite
                MySpriteRenderer.flipX = false;
            }
		}

		// jump
		if(Input.GetKeyDown (KeyCode.Space) && grounded){
			Jump();
		}
		//double jump
		if(grounded) 
			DoubleJump = false;

		if(Input.GetKeyDown (KeyCode.Space) && !DoubleJump && !grounded) {
			Jump();
			DoubleJump = true;
		}

		//non-stick player
		MoveVelocity = 0f;
		
		// move
		if(Input.GetKey (KeyCode.D)){
			// GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = MoveSpeed;
		}
		if(Input.GetKey (KeyCode.A)){
			// GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = -MoveSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}


}
