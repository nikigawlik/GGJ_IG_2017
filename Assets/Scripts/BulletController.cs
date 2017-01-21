using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Vector3 speed;
	public Quaternion Rotation;
	float screenWidth;
	float screenHeight;
	public Camera cam;


	// Use this for initialization
	void Start () {
		this.transform.rotation = Rotation;
		screenWidth = 2f * cam.orthographicSize * cam.aspect;
		screenHeight = 2f * cam.orthographicSize;
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll) {
			Destroy (this.gameObject);
			coll.gameObject.GetComponent<hasLives> ().getHit ();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = this.transform.position  + speed/2;




		if (	this.transform.position.x >= screenWidth / 2 
			|| 	this.transform.position.y >= screenHeight / 2 
			|| 	this.transform.position.x <= -screenWidth / 2 
			||	this.transform.position.y <= -screenHeight / 2) {

			Destroy (this.gameObject, 2f);
		}
	}



}
