using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSurf : MonoBehaviour {

	public GameObject lineHolder;
	public float gravFactor;

	private Vector2 velocity = new Vector2 (0, 0);


	private WavePointGenerator wavePointGen;
	private waveMotion waveMot;

	// Use this for initialization
	void Start () {
		wavePointGen = lineHolder.GetComponent<WavePointGenerator> ();
		waveMot = lineHolder.GetComponent<waveMotion> ();
	}

	void FixedUpdate () {
		Vector2 pos = this.transform.position;

		velocity.y += getGravity();

		pos.y = waveMot.GetYAt (pos.x);

		Debug.Log (pos.x);

		this.transform.position = pos + velocity;

		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180f / Mathf.PI * Mathf.Atan(waveMot.GetSlopeAt (pos.x))));
	}

	float getGravity() {
		Vector2 pos = this.transform.position;

		return pos.y * gravFactor * -1f;
	}
}
