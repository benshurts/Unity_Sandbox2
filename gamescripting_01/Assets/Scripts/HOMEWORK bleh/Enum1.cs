using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum1 : MonoBehaviour {

	public int coins;
	
	enum Inventory { meat = 2,cheese =10,sword = 3,shield =12, map =44, bow,arrows = 34 };

	private void Start() {
		//	print{Inventory.cheese};
	}
}
