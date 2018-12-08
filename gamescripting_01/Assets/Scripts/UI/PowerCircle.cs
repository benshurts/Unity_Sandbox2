using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCircle : MonoBehaviour {

	Image filling;
	public GameObject PowerCircleAll;
	public GameObject PowerGroup;
	CanvasGroup PowerGroupHide;
	public Color StartColor;
	public Color EndColor;
	public Color ColorChange;
	private float StartTime;
	public static float fillAmt;
	float FillSpeed;
	float ShootSpeed;
	float coolDownTimer;

	Color CantShootColor;


	private void Start() {
		StartTime = Time.time;
		PowerCircleAll = GameObject.Find("PowerBarBack");
		PowerGroup = GameObject.Find("PowerGroup");
		PowerGroupHide = PowerGroup.GetComponent<CanvasGroup>();
		CantShootColor = GameObject.Find("PowerBarBack").GetComponent<Image>().color;

		// PowerCanvas = Canvas.Find("CanvasPower");
	}
	private void Update() {
		coolDownTimer = GameObject.Find("Shooter").GetComponent<playerShoot>().CoolDownTimer;
		//fade in when click fade out after
		if((fillAmt > 0) && (fillAmt < 1)) {
			PowerGroupHide.alpha += 0.2f;
		} else PowerGroupHide.alpha -= .04f;
		FillSpeed = Mathf.Lerp(0.0f,0.9f,0.5f);

		if(fillAmt < 0) fillAmt = 0;
		// print(coolDownTimer);
		//fade in but no bar before shoot timer
		if(coolDownTimer > 0 && Input.GetMouseButton(0)){
			PowerGroupHide.alpha += 0.5f;
			CantShootColor = Color.red;
			// CantShootColor = Color.Lerp(Color.black,Color.red,Time.deltaTime*10);
		} else CantShootColor = Color.black;

		if(Input.GetMouseButton(0) && coolDownTimer == 0){
			fillAmt = GetComponent<Image>().fillAmount += 0.0f + (Time.deltaTime*FillSpeed);
			ColorChange = GetComponent<Image>().color += Color.Lerp(StartColor,EndColor,Time.deltaTime*fillAmt);


			// ColorChange = GetComponent<Image>().color += Color.Lerp(StartColor,EndColor,Time.deltaTime*FillSpeed);
		} else if(fillAmt > 0) {
			ShootSpeed = GameObject.Find("Shooter").GetComponent<playerShoot>().FinalShootSpeed;

			// FillSpeed = (Mathf.Sin(Mathf.Lerp(0.9f,0.0f,0.5f)));
			fillAmt = GetComponent<Image>().fillAmount -= 0.0f + Time.deltaTime*(ShootSpeed/2);
			// ColorChange = GetComponent<Image>().color += Color.LerpUnclamped(StartColor,EndColor,Time.deltaTime*fillAmt);

			// ColorChange = GetComponent<Image>().color -= Color.Lerp(StartColor,EndColor,Time.deltaTime*UnFillSpeed);
		}
		if(GetComponent<Image>().fillAmount == 0.0f) {
			GetComponent<Image>().color = Color.red;
		}

		// print(fillAmt);

		// print("Time time " + Time.time);
	}

}
