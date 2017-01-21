using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSurf : MonoBehaviour {

	public GameObject lineHolder;
	public float gravFactor;

	private Vector2 velocity = new Vector2 (0, 0);


	private WavePointGenerator wavePointGen;
	private waveMotion waveMot;

	private bool airborne = false;

	private Vector2 prevPos;

	// Use this for initialization
	void Start () {
		wavePointGen = lineHolder.GetComponent<WavePointGenerator> ();
		waveMot = lineHolder.GetComponent<waveMotion> ();

		prevPos = transform.position;
	}

	void FixedUpdate () {
		Vector2 pos = this.transform.position;


		// jump
		if (Input.GetKeyDown ("space")) { //TODO change this ;)
			if (!airborne) {
				airborne = true;
				float deltaV = transform.position.y - prevPos.y;
				velocity.y = deltaV;
			} else {
				airborne = false; //TODO check for line proximity
			}
		}

		//snap
		if (!isAirborne ()) {

			pos.y = waveMot.GetYAt (pos.x);
		}
		else {
			velocity.y += getGravity ();
			pos = pos + velocity;
		}

		prevPos = transform.position;
		this.transform.position = pos;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180f / Mathf.PI * Mathf.Atan(waveMot.GetSlopeAt (pos.x))));
	}

	bool isAirborne() {
		return airborne;
	}

	float getGravity() {
		Vector2 pos = this.transform.position;

		return pos.y * gravFactor * -1f;
	}
}
