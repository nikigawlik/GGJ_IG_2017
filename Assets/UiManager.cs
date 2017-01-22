using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	public GameObject[] boxes;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPlayers(GameObject[] players) {
		for (int i = 0; i < 4; i++) {
			updateScore us = boxes [i].GetComponent<updateScore> ();
			us.player = players [i];
			boxes [i].GetComponent<Image> ().color = players [i].GetComponent<SpriteRenderer> ().color;
		}
	}
}
