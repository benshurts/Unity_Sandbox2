using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

	public float Power = 0.7f;
	public float Duration = 1.0f;
	public Transform Camera;
	public float SlowDownAmount = 1.0f;
	public bool ShouldShake = false;

	private Vector3 StartPosition;
	private float InitDuration;

	void start() {
		Camera = Camera.transform;
		StartPosition = Camera.localPosition;
		InitDuration = Duration;
	}

	void update() {
		if(ShouldShake) {
			if(Duration > 0) {
				Camera.localPosition = StartPosition + Random.insideUnitSphere * Power;
				Duration -= Time.deltaTime * SlowDownAmount;
			}
			else
			{
				ShouldShake = false;
				Duration = InitDuration;
				Camera.localPosition = StartPosition;
			}
		}
	}
}
