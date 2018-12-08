using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurstKill : MonoBehaviour {

	void Update ()
	{
	if (GetComponent<ParticleSystem>() != null && GetComponent<ParticleSystem>().particleCount == 0)
		Destroy(gameObject);
	}
}
