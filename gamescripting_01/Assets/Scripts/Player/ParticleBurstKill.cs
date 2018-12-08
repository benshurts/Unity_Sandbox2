using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurstKill : MonoBehaviour {
	float timer;

	private void Start() {
		timer = 0.5f;
	}
	void Update ()	{
		timer -= 0.2f;
		if(timer < 0) timer = 0;

		if (GetComponent<ParticleSystem>() != null && GetComponent<ParticleSystem>().particleCount == 0 && timer == 0)
			Destroy(this.gameObject);
		}
}
