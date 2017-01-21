using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public float amplitudeMax;
	public float amplitudeMin;
	public float amplitudeProbability;
	public float timeSpeedMax;
	public float timeSpeedMin;
	public float timeSpeedProbability;
	public float xVersatzMax;
	public float xVersatzMin;
	public float xVersatzProbability;
	public float yVersatzMax;
	public float yVersatzMin;
	public float yVersatzProbability;
	private WavePointGenerator wavePointGen;

	// Use this for initialization
	void Start () {
		wavePointGen = GetComponent<WavePointGenerator> ();
	}

	void changeParam(ref float param, ref float max, ref float min){
		param = min + (max-min) * Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		if ( ( Random.value * 100) > (100 - amplitudeProbability) ) {
			changeParam (ref wavePointGen.targetAmplitudeOne, ref amplitudeMax, ref amplitudeMin);
		}
		if ( ( Random.value * 100) > (100 - amplitudeProbability) ) {
			changeParam (ref wavePointGen.targetAmplitudeTwo, ref amplitudeMax, ref amplitudeMin);
		}
		if ( ( Random.value * 100) > (100 - timeSpeedProbability) ) {
			changeParam (ref wavePointGen.targetTimeSpeedOne, ref timeSpeedMax, ref timeSpeedMin);
		}
		if ( ( Random.value * 100) > (100 - timeSpeedProbability) ) {
			changeParam (ref wavePointGen.targetTimeSpeedTwo, ref timeSpeedMax, ref timeSpeedMin);
		}
		if ( ( Random.value * 100) > (100 - xVersatzProbability) ) {
			changeParam (ref wavePointGen.targetXVersatzOne, ref xVersatzMax, ref xVersatzMin);
		}
		if ( ( Random.value * 100) > (100 - xVersatzProbability) ) {
			changeParam (ref wavePointGen.targetXVersatzTwo, ref xVersatzMax, ref xVersatzMin);
		}
		if ( ( Random.value * 100) > (100 - yVersatzProbability) ) {
			changeParam (ref wavePointGen.targetYVersatzOne, ref yVersatzMax, ref yVersatzMin);
		}
		if ( ( Random.value * 100) > (100 - yVersatzProbability) ) {
			changeParam (ref wavePointGen.targetYVersatzTwo, ref yVersatzMax, ref yVersatzMin);
		}
	}
}
