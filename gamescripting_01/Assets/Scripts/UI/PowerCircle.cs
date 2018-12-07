using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCircle : MonoBehaviour {

	Image filling;
	public float fillAmt;
	float FillSpeed;
	float Fill;
	float StartFill = 0f;

	private void Start() {
		// filling = this.GetComponent<Image>();
		// fillAmt = this.GetComponent<Image>().fillAmount;
		// FillSpeed = 0.4f;
		FillSpeed = Mathf.Lerp(0.0f,0.9f,0.5f);


	}
	private void Update() {
		if(fillAmt < 0) fillAmt = 0;
		if(Input.GetMouseButton(0)){
			fillAmt = GetComponent<Image>().fillAmount += 0.0f + (Time.deltaTime*FillSpeed);

			// filling.fillAmount += Mathf.Lerp(0f, 10f, 0.0f);
			// filling.fillAmount += FillSpeed * Time.deltaTime;
		} else if(fillAmt > 0) {
			fillAmt = GetComponent<Image>().fillAmount -= 0.0f + Time.deltaTime;

		}
		// print(fillAmt);

		// print("Time time " + Time.time);
	}

}
