using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sudocode : MonoBehaviour {

	public int dogs;
	public int floofs;
	private int total;
	//cool beans
	void start(){
		addition(dogs, floofs);
	}

	void addition(int One, int Two){
		total = One + Two;
		print(total);
	}
}
