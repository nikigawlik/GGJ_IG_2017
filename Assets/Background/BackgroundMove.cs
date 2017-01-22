using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

	public float myX;
	public Transform myTransform;
	public float speed;
	public Vector3 speedVect = new Vector3(0,0,0);
	[HideInInspector()]
	public Camera cam;
	private float screenWidth;
	public bool[] startPos = new bool[3];
	private float screenPixels;
	private float ScaleSize;
	// Use this for initialization
	void Start () {
	

		myTransform = this.gameObject.GetComponent<Transform> ();
		myX = myTransform.position.x;
		speedVect.x = -speed;
		cam = Camera.main;
		screenWidth = 2f * cam.orthographicSize * cam.aspect;

		screenPixels = screenWidth * 100;
		ScaleSize = screenPixels/ 1920; 
		myTransform.localScale = new Vector3 (ScaleSize, ScaleSize, 1.0f);


		if (startPos[0] == true) {
			myTransform.position = new Vector3 (0, 0, 100);
		}
		if (startPos[1] == true) {
			myTransform.position = new Vector3 (screenWidth, 0, 100);
		}
		if (startPos[2] == true) {
			myTransform.position = new Vector3 (screenWidth * 2, 0, 100);
		}
	}
	
	// Update is called once per frame
	void Update () {
		myX = this.gameObject.GetComponent<Transform> ().position.x;
			

		if(myX <= -screenWidth){
			myTransform.position = new Vector3 (2*screenWidth, 0, 100);
			}

		myTransform.Translate(speedVect.x * Vector3.right * Time.deltaTime);
			
	}
}
