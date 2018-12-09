using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
	public int Lives;
	public int NumOfLives;

	public Image[] LivesArr;
	public Sprite FullLife;
	public Sprite EmptyLife;

	private void Update() {
		//no more lives than num of lives allowed
		if(Lives > NumOfLives) Lives = NumOfLives;

		for(int i = 0; i < LivesArr.Length; i++) {
			//current lives
			if(i < Lives){
				LivesArr[1].sprite = FullLife;
			} else {
				LivesArr[i].sprite = EmptyLife;
			}
			//extra lives
			if(i < NumOfLives){
				LivesArr[i].enabled = true;
			} else {
				LivesArr[i].enabled = false;
			}
		}
	}
}
