using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrows : MonoBehaviour {

	public int playerNr = 0;
	private Vector3 screenPos;
	private Camera cam;
	private GameObject character;
	private SpriteRenderer arrowRenderer;
	public float objectSize = 0.33f;

	// Use this for initialization
	void Start () {
		arrowRenderer = gameObject.GetComponent<SpriteRenderer> ();
		character = GameObject.FindGameObjectsWithTag("Player")[playerNr];
		arrowRenderer.color = character.GetComponent<SpriteRenderer> ().color;
		arrowRenderer.enabled = false;
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		screenPos = cam.WorldToViewportPoint(character.transform.position);
		if(screenPos.y>1.0f){
//			Debug.Log ("yay");
			gameObject.GetComponent<SpriteRenderer> ().flipY = true;
			transform.position = new Vector3 (character.transform.position.x,cam.orthographicSize-objectSize, 2.0f);
			arrowRenderer.enabled = true;
		}
		else if (screenPos.y < 0.0f) {
			gameObject.GetComponent<SpriteRenderer> ().flipY = false;
			transform.position = new Vector3 (character.transform.position.x, -(cam.orthographicSize - objectSize), 2.0f);
			arrowRenderer.enabled = true;
		} else {
			//Debug.Log (screenPos.y);
			arrowRenderer.enabled = false;
		}
	}

}
