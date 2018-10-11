using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixelCamera : MonoBehaviour {
	public Camera pixelCam;
	    public void Awake()
    {
        //
		pixelCam = GetComponent<Camera>();
        //pixelCam = (Screen.height / 32f / 2.0f); // 100f is the PixelPerUnit that you have set on your sprite. Default is 100.
		
    }

}
