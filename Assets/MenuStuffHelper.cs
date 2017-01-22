using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStuffHelper : MonoBehaviour {

	public GameObject[] players;

	// Use this for initialization
	void Start () {
		// set boxes
		UiManager um = GameObject.Find("UIManager").GetComponent<UiManager>();
		um.SetPlayers (players);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
