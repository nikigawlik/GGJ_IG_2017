using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrows : MonoBehaviour {

	private Vector3 screenPos;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = cam.WorldToViewportPoint(transform.position);
		if (screenPos.y > 1 || screenPos.y < 0) {
			
		}
	}
}
