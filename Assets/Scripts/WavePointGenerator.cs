/*
 * Generates 1 point/frame to be used as the y- coordinate of a wave
 * access pointQueue!
 * use as script for your wave
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePointGenerator : MonoBehaviour {

	//List of all HEIGHTS of all Wavepoints on screen
	public List<float> pointList = new List<float>();
	public int maxPoints;
	public float slownessFactor = 1.0f;


	//Wave One
	private float amplitudeOne;
	private float xVersatzOne;
	private float yVersatzOne;
	private float amplitudeOneLast;
	private float xVersatzOneLast;
	private float yVersatzOneLast;
	public float targetAmplitudeOne;
	public float frequencyOne;
	public float targetXVersatzOne;
	public float targetYVersatzOne;
	//Wave Two
	private float amplitudeTwo;
	private float xVersatzTwo;
	private float yVersatzTwo;
	private float amplitudeTwoLast;
	private float xVersatzTwoLast;
	private float yVersatzTwoLast;
	public float targetAmplitudeTwo;
	public float frequencyTwo;
	public float targetXVersatzTwo;
	public float targetYVersatzTwo;

	//factor for how fast the current parameter will change to the target parameter
	public float changeSmoothness;  //smoother when lower
	public float changeTolerance;  //when is current set to target

	//own time and it's growth speed
	private float ownTimeOne;
	private float ownTimeTwo;
	private float timeSpeedOne;
	private float timeSpeedTwo;
	private float timeSpeedOneLast;
	private float timeSpeedTwoLast;
	public float targetTimeSpeedOne;
	public float targetTimeSpeedTwo;

	// Use this for initialization
	void Start () {
	
		amplitudeOne = targetAmplitudeOne;
		xVersatzOne = targetXVersatzOne;
		yVersatzOne = targetYVersatzOne;
		ownTimeOne = 0.0f;
		timeSpeedOne = targetTimeSpeedOne;

		amplitudeTwo = targetAmplitudeTwo;
		xVersatzTwo = targetXVersatzTwo;
		yVersatzTwo = targetYVersatzTwo;
		ownTimeTwo = 0.0f;
		timeSpeedTwo = targetTimeSpeedTwo;

		for (int x = 0; x < (slownessFactor * maxPoints); x++) {
			pointList.Add(0);
		}
	}
	
	void setSmoothValue(ref float current, ref float last, ref float target){
		if (Mathf.Abs (current - target) <= (changeTolerance * changeSmoothness) * (Mathf.Abs (last - target))) {
			if (current != target) {
				current = target;
			}
			last = current;
		}
		else if (Mathf.Abs (current - target) > Mathf.Abs (last - target)) {
			current += 2 * changeSmoothness * (target - current);
		}
		else{
			current += changeSmoothness*(target - last);
		}
	}


	void FixedUpdate (){
		targetAmplitudeOne = Mathf.Abs (targetAmplitudeOne);
		targetAmplitudeTwo = Mathf.Abs (targetAmplitudeTwo);
		frequencyOne = Mathf.Abs (frequencyOne);
		frequencyTwo = Mathf.Abs (frequencyTwo);
		targetXVersatzOne = Mathf.Abs (targetXVersatzOne);
		targetXVersatzTwo = Mathf.Abs (targetXVersatzTwo);
		//targetYVersatzOne = Mathf.Abs (targetYVersatzOne);
		//targetYVersatzTwo = Mathf.Abs (targetYVersatzTwo);
		targetTimeSpeedOne = Mathf.Abs (targetTimeSpeedOne);
		targetTimeSpeedTwo = Mathf.Abs (targetTimeSpeedTwo);
		//change amplitude gradually 
		setSmoothValue(ref amplitudeOne, ref amplitudeOneLast, ref targetAmplitudeOne);
		setSmoothValue(ref amplitudeTwo, ref amplitudeTwoLast, ref targetAmplitudeTwo);
		setSmoothValue(ref timeSpeedOne, ref timeSpeedOneLast, ref targetTimeSpeedOne);
		setSmoothValue(ref timeSpeedTwo, ref timeSpeedTwoLast, ref targetTimeSpeedTwo);
		setSmoothValue(ref xVersatzOne, ref xVersatzOneLast, ref targetXVersatzOne);
		setSmoothValue(ref xVersatzTwo, ref xVersatzTwoLast, ref targetXVersatzTwo);
		setSmoothValue(ref yVersatzOne, ref yVersatzOneLast, ref targetYVersatzOne);
		setSmoothValue(ref yVersatzTwo, ref yVersatzTwoLast, ref targetYVersatzTwo);
		
		ownTimeOne += timeSpeedOne;
		ownTimeTwo += timeSpeedTwo;

		float newHeight = amplitudeOne * Mathf.Sin ((float)((frequencyOne/slownessFactor) * ownTimeOne + xVersatzOne)) + yVersatzOne
			+ 		amplitudeTwo * Mathf.Sin ((float)((frequencyTwo/slownessFactor) * ownTimeTwo + xVersatzTwo)) + yVersatzTwo;
		
		pointList.Add(newHeight);


		pointList.RemoveAt (0);



	}
}