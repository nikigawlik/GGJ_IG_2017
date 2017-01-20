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


	//Wave One
	public float amplitudeOne;
	public float frequencyOne;
	public float xVersatzOne;
	public float yVersatzOne;
	//Wave Two
	public float amplitudeTwo;
	public float frequencyTwo;
	public float xVersatzTwo;
	public float yVersatzTwo;



	// Use this for initialization
	void Start () {
//		newHeight = 0;
//		//Wave One
//		frequencyOne = 1;
//		amplitudeOne = 1;
//		xVersatzOne = 0;
//		yVersatzOne = 0;
//		//Wave Two
//		amplitudeTwo = 0;
//		frequencyTwo = 0;
//		xVersatzTwo = 0;
//		yVersatzTwo = 0;

	}
	



	void FixedUpdate (){

		//change aplitude gradually 




		float newHeight = amplitudeOne * Mathf.Sin ((float)(frequencyOne * Time.time + xVersatzOne)) + yVersatzOne
			+ 		amplitudeTwo * Mathf.Sin ((float)(frequencyTwo * Time.time + xVersatzTwo)) + yVersatzTwo;
		
		pointList.Add(newHeight);
		if (pointList.Count >= maxPoints){
			pointList.Remove (0);

		}


	}
}
