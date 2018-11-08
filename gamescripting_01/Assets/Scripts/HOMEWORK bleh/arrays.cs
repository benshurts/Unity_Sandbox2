using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrays : MonoBehaviour {

	public string[] pets = {"cram", "spam", "oink", "cringo", "shmingo"};

	private void Start() {
		foreach (var item in pets)
		{
			//do a thing
		}
	}
}
