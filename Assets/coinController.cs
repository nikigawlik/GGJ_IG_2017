using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour {

	public Vector3 coinVelocity;
	public float coinSpeed;
	public float maxSpeed;

	public void moveCoin ( Vector3 directionNormal){
		coinVelocity += directionNormal * coinSpeed;
		if (coinVelocity.magnitude > maxSpeed) {
			coinVelocity = coinVelocity.normalized * maxSpeed/2;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		this.transform.position += coinVelocity;
	}
}
