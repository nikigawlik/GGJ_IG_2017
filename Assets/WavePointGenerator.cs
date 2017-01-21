/*
 * Generates 1 point/frame to be used as the y- coordinate of a wave
 * access pointQueue!
 * use as script for your wave
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
	

		for (int x = 0; x < maxPoints; x++) {
			pointList.Add(0);
		}
	}
	



	void FixedUpdate (){

		//change aplitude gradually 




		float newHeight = amplitudeOne * Mathf.Sin ((float)(frequencyOne * Time.time + xVersatzOne)) + yVersatzOne
			+ 		amplitudeTwo * Mathf.Sin ((float)(frequencyTwo * Time.time + xVersatzTwo)) + yVersatzTwo;
		
		pointList.Add(newHeight);


		pointList.RemoveAt (0);




	}
}
