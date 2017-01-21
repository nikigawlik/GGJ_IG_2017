using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSurf : MonoBehaviour {

	public Queue<double> wave; // TODO this will be wave yo

	private Vector2 velocity = new Vector2 (0, 0);

	public float gravFactor;


	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		Vector2 pos = this.transform.position;

		velocity.y += getGravity();

		this.transform.position = pos + velocity;
	}

	float getGravity() {
		Vector2 pos = this.transform.position;

		return pos.y * gravFactor * -1f;
	}
}
