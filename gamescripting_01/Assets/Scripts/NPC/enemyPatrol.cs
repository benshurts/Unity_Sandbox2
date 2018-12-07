using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
	public Transform OriginPoint;
	public Transform DownCheck;
	private Vector2 dir = new Vector2(1,0);
	public float range;
	public float speed;
	Rigidbody2D rb;
	Collider2D col;
	public LayerMask GroundLayerMask;
	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update() {
		// Debug.DrawRay(OriginPoint.position,dir,Color.red,range);
		// Debug.DrawRay(DownCheck.position,Vector2.down,Color.red,range);

		RaycastHit2D downHit = Physics2D.Raycast(DownCheck.position,Vector2.down,range,GroundLayerMask.value);
		RaycastHit2D hit = Physics2D.Raycast(OriginPoint.position,dir,range,GroundLayerMask.value);
		// print("Rayhit " + hit);

		if(hit == true || downHit == false){

				FLip();
				speed *= -1;
				dir *= -1;

		}
	}
	void FLip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private void FixedUpdate() {
		rb.velocity = new Vector2(speed,rb.velocity.y);
	}

}
