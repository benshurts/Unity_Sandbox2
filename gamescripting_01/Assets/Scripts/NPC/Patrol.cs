using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public float speed;
	private bool movingRight = true;
	public Transform groundDetection;
	public Transform rightWallDetection;
	public Transform leftWallDetection;
	

	void Update() {
		//move right smoothly
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		//raycast check for end of platform
		//right wall
		// RaycastHit2D rightWallInfo = Physics2D.Raycast(rightWallDetection.position, Vector2.right, 0.5f);
		// Debug.DrawLine(rightWallDetection.position,new Vector3(0.5f,0,0),Color.red);
		// //left wall
		// RaycastHit2D leftWallInfo = Physics2D.Raycast(leftWallDetection.position, Vector2.left, 0.5f);
		// Debug.DrawLine(leftWallDetection.position,new Vector3(-0.5f,0,0),Color.red);
		//down
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);
		Debug.DrawLine(groundDetection.position,new Vector3(0,-0.5f,0),Color.red);
		// if(rightWallInfo.collider != null) {
		// 	movingRight = !movingRight;
		// }
		// if(leftWallInfo.collider != null) {
		// 	movingRight = !movingRight;
		// }
		if(groundInfo.collider == false) {
			movingRight = !movingRight;
			
		}
		if(movingRight == true){
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
			} else {
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}
	}
}
