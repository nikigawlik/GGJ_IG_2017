using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theWinningScript : MonoBehaviour {

	public GameObject[] players = new GameObject[4];
//	public GameObject endscreen;

	public GameObject thor1;
	public GameObject thor2;


	void Start(){
		
//		endscreen.SetActive (false);
		//endscreen.GetComponent<SpriteRenderer> ().enabled = false;
	}
	// Use this for initialization
	void WIN (string whoWon) {
//		endscreen.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject plyr in players){
			if (plyr.transform.position.x == 8) {
				WIN (plyr.ToString());
			}
		}

		//random Movement
		//Vector2 randomMove = new Vector2
		thor1.transform.position = new Vector2(thor1.transform.position.x , (float) (0.5 * Mathf.Sin ((float)(1 * Time.time)) + 3.5 ));
		thor2.transform.position = new Vector2(thor1.transform.position.x , (float) (-0.5 * Mathf.Cos ((float)(1 * Time.time)) - 3.5 ));
	}
}
