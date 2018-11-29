using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//make sure there is always a line renderer
[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {

	//get line renderer
	LineRenderer lr;

	//vars for solving velocity arc
	public float Velocity;
	public float Angle;

	float g; //force of gravity on Y axis ---absolute value of gravity not negative value

	float RadianAngle;//theta symbol in equation-- convert radians to degrees.
	//controll the segments of the arc
	public int Resolution;

	private void Awake() {
		//get linerenderer
		lr = GetComponent<LineRenderer>();
		//get absolute value of the force of gravity
		g = Mathf.Abs (Physics2D.gravity.y);
	}

	void OnValidate() {
		//check that lr is not null and the game is playing or things will break -- can call before awake
		if(lr != null && Application.isPlaying) {
			RenderArc();
		}
	}

	private void Start() {
		//render arc
		RenderArc();
	}

	//populating line renderer with the apropriate settings
	void RenderArc(){
		lr.positionCount = Resolution + 1;
		lr.SetPositions(CalcArcArray());
	}

	//create array of vector3 positions for arc
	Vector3[] CalcArcArray() {
		Vector3[] ArcArray = new Vector3[Resolution + 1];
		RadianAngle = Mathf.Deg2Rad * Angle;
		float MaxDist = (Velocity * Velocity * Mathf.Sin(2 * RadianAngle)) / g;

		for (int i = 0; i <= Resolution; i++)
		{
			float t = (float)i / (float)Resolution;
			ArcArray[i] = CalcArcPoint(t,MaxDist);
		}

		return ArcArray;
	}

	//calculate height and distance of each vertex in the array
	Vector3 CalcArcPoint(float t, float maxDistance){
		float x = t * maxDistance;
		float y = x * Mathf.Tan(RadianAngle) - ((g * x * x)/(2 * Velocity * Velocity * Mathf.Cos(RadianAngle) * Mathf.Cos(RadianAngle)));
		return new Vector3(x,y);
	}

}