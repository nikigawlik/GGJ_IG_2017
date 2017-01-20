using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePointGenerator : MonoBehaviour {

	//List of all HEIGHTS of all Wavepoints on screen
	public Queue<double> pointQueue;
	public int maxPoints;

	private double newHeight;


	//Wave One
	public double amplitudeOne;
	public double frequencyOne;
	public double xVersatzOne;
	public double yVersatzOne;
	//Wave Two
	public double amplitudeTwo;
	public double frequencyTwo;
	public double xVersatzTwo;
	public double yVersatzTwo;



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
		newHeight = amplitudeOne * Mathf.Sin ((float)(frequencyOne * Time.time + xVersatzOne)) + yVersatzOne
			+ 		amplitudeTwo * Mathf.Sin ((float)(frequencyTwo * Time.time + xVersatzTwo)) + yVersatzTwo;
		
		pointQueue.Enqueue(newHeight);
		if (pointQueue.Count >= maxPoints){
			pointQueue.Dequeue ();

		}


	}
}
