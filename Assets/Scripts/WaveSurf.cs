using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSurf : MonoBehaviour {

	public GameObject lineHolder;
	public float gravFactor;
	public float advSpeed;
	public float retrSpeed;
	public float airborneDrag;
	public float jumpFactor;
	private Vector2 oldPos;
	private Vector2 velocity;
	private float targetRotation;


	private WavePointGenerator wavePointGen;
	private waveMotion waveMot;

	private bool airborne = false;

	// Use this for initialization
	void Start () {
		wavePointGen = lineHolder.GetComponent<WavePointGenerator> ();
		waveMot = lineHolder.GetComponent<waveMotion> ();

		velocity = new Vector2 (advSpeed, 0);
	}

	void Update() {
		Vector2 pos = this.transform.position;
		// jump
		if (Input.GetButtonDown ("Jump") && airborne == false) { //TODO change this ;)
			
			airborne = true;
			velocity = transform.rotation * (Vector2.right * jumpFactor);
			//velocity.x = retrSpeed;
			velocity.x = 0;
		} else if (!Input.GetButton ("Jump") &&
			(oldPos.y >= waveMot.GetYAt (pos.x) && pos.y <= waveMot.GetYAt (pos.x)  ||
			 oldPos.y <= waveMot.GetYAt (pos.x) && pos.y >= waveMot.GetYAt (pos.x)  )
			&& airborne == true) {

			airborne = false; 
			velocity.x -= retrSpeed;
		}
	}

	void FixedUpdate () {
		Vector2 pos = this.transform.position;

		if (isAirborne ()) {
			// drag 
			velocity.x -= airborneDrag;

		} else {
			velocity.x = advSpeed;
		}


		//snap
		if (!isAirborne ()) {
			velocity.y = 0;
			pos.y = waveMot.GetYAt (pos.x);
		}
		else {
			velocity.y += getGravity ();
		}
		oldPos = pos;
		pos = pos + velocity;

		this.transform.position = pos;

		/*
		 * rotation: 
		 */
		if (isAirborne ()) {
			targetRotation = Mathf.Atan (velocity.y / waveMot.getWaveSpeed ());
		}
		else
			targetRotation = Mathf.Atan (waveMot.GetSlopeAt (pos.x));
		
		//float lerp = 0.1f;
		Quaternion targetQ = Quaternion.Euler (new Vector3 (0, 0, 180f / Mathf.PI * targetRotation));
		this.transform.rotation = targetQ;
	}

	bool isAirborne() {
		return airborne;
	}

	float getGravity() {
		Vector2 pos = this.transform.position;

		return Mathf.Sign(pos.y - waveMot.GetYAt(transform.position.x)) * gravFactor * -1f;
	}
}
