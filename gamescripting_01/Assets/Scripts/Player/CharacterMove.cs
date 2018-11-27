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
		if(Ammo > 0) {
			// JumpHeight = Ammo - Ammo + (1*Ammo);
			JumpHeight = Mathf.Lerp(1,Ammo,Ammo);
			JumpHeight = -JumpHeight;
			if(JumpHeight < 0) JumpHeight = -JumpHeight;
			
			// switch (Ammo) {
				
			// 	case 10:
			// 		JumpHeight = 1f;
			// 		break;
				
			// 	case 9:
			// 		JumpHeight = 2f;
			// 		break;
				
			// 	case 8:
			// 		JumpHeight = 3f;
			// 		break;
				
			// 	case 7:
			// 		JumpHeight = 4f;
			// 		break;
				
			// 	case 6:
			// 		JumpHeight = 5f;
			// 		break;
				
			// 	case 5:
			// 		JumpHeight = 4f;
			// 		break;
				
			// 	case 4:
			// 		JumpHeight = 5f;
			// 		break;
				
			// 	case 3:
			// 		JumpHeight = 6f;
			// 		break;
				
			// 	case 2:
			// 		JumpHeight = 7f;
			// 		break;
				
			// 	case 1:
			// 		JumpHeight = 8f;
			// 		break;
			// }
		}
		Debug.Log("JumpHeight " + JumpHeight);
		
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