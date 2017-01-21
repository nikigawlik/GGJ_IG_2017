using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSurf : MonoBehaviour {

	public string jumpButton;


	public float gravFactor;
	public float advSpeed;
	public float retrSpeed;
	public float airborneDrag;
	public float jumpFactor;
	public float constJump;
	private Vector2 oldPos;
	private Vector2 veryOldPos;
	private Vector2 velocity;
	private float targetRotation;

	public GameObject lineHolder;
	private GameObject[] lineHolders;

	private WavePointGenerator wavePointGen;
	private waveMotion waveMot;

	private bool airborne = false;

	// Use this for initialization
	void Start () {
		

		UpdateWaveComps ();

		lineHolders = GameObject.FindGameObjectsWithTag ("Wave");

		velocity = new Vector2 (advSpeed, 0);
	}

	void UpdateWaveComps () {
		wavePointGen = lineHolder.GetComponent<WavePointGenerator> ();
		waveMot = lineHolder.GetComponent<waveMotion> ();
	}

	void Update() {
		Vector2 pos = this.transform.position;
		// jump
		if (Input.GetButtonDown (jumpButton) && airborne == false) { 
			
			airborne = true;
			velocity = transform.rotation * (Vector2.right * jumpFactor);
			//velocity = new Vector2(0f,0.01f);
			velocity.y += Mathf.Sign (velocity.y) * constJump;
			//velocity.x = retrSpeed;
			velocity.x = 0;

			//LAND
		} else if (!Input.GetButton (jumpButton) &&  airborne == true) {
			foreach (GameObject wave in lineHolders) 
			{
				waveMot = wave.GetComponent<waveMotion> ();
				if ((oldPos.y >= waveMot.GetYAt (oldPos.x) || veryOldPos.y >= waveMot.GetYAt (veryOldPos.y)) && pos.y <= waveMot.GetYAt (pos.x) ||
				   (oldPos.y <= waveMot.GetYAt (oldPos.x) || veryOldPos.y <= waveMot.GetYAt (veryOldPos.y)) && pos.y >= waveMot.GetYAt (pos.x)) {

					airborne = false;
                    ParticleSystem VFX = this.gameObject.GetComponentInChildren<ParticleSystem>();
                    VFX.Play();
					velocity.x -= retrSpeed;
					// set this curve
					lineHolder = wave;
					break;
				}
			}
		}
	}

	void FixedUpdate () {
		Vector2 pos = this.transform.position;

		//-------------------X Movement
		if (isAirborne ()) {
			// drag 
			velocity.x = -(airborneDrag * ((pos.x + 10)/20));

			//Explaination? See below!

		} else {
			//Screen X coordinates range from -10 to 10 
			//velocity should be 1*advSpeed on the very left and 0*advSpeed on the far right
			velocity.x = advSpeed * (1-(pos.x + 10)/20);
		}
		//------------------Y Movement
		if (!isAirborne ()) {
			velocity.y = 0;
			pos.y = waveMot.GetYAt (pos.x);
		}
		else {
			velocity.y += getGravity ();
		}


		//For Landing
		veryOldPos = oldPos;
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
		//return Mathf.Sign(pos.y) * gravFactor * -1f;
		//return gravFactor * -1f;
	}
}
