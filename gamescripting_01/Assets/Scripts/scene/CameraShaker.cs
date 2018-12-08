﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

	public IEnumerator Shake(float duration, float magnitude){
		Vector3 orginialPos = transform.localPosition;

		float elapsed = 0f;

		while(elapsed < duration){
			float x = Random.Range(-1f,1f) * magnitude;
			float y = Random.Range(-1f,1f) * magnitude;

			transform.localPosition = new Vector3(x,y,orginialPos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}
		transform.localPosition = orginialPos;
		print("Shake");
	}

}
