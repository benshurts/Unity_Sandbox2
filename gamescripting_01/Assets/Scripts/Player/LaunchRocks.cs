using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocks : MonoBehaviour {

	public Rigidbody2D Bullet;
	public Transform Target;

	public float h = 25; //height
	public float g = -18; //gravity

	private void Start() {
		//if 3d turn use gravity to false 
	}
	private void Update() {
		//input to trigger launch
	}

	void Launch(){
		//use gravity at launch
		Bullet.velocity = CalcLaunchVel();
	}

	Vector2 CalcLaunchVel(){
		float DispY = Target.position.y - Bullet.position.y;
		Vector2 DispX = new Vector2 (Target.position.x - Bullet.position.x, 0);

		Vector2 VelY = Vector2.up * Mathf.Sqrt(-2 * g * h);
		Vector2 VelX = DispX / (Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * DispY - h) / g);

		return VelX + VelY;
	}
}
