using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour {
	private SpriteRenderer rend;
	public Sprite cursor2;
	public Sprite normalCursor;
	private void Start() {
		rend = GetComponent<SpriteRenderer>();
		Cursor.visible = false;
	}
	private void Update() {
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = cursorPos;

		//mouse click down change cursor sprite
		if(Input.GetMouseButtonDown(0)){
			rend.sprite = cursor2;
		} else if(Input.GetMouseButtonUp(0)){
			rend.sprite = normalCursor;
		}
	}
}
