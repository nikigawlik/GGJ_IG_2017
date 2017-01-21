using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasLives : MonoBehaviour {

	public int lives;
	public Camera cam;

	void die(){
		//respawn
		// fixed this -Nils ;)
		Vector2 pos = transform.position;
		pos.x = (float) (-cam.orthographicSize * cam.aspect + 0.4 );
		transform.position = pos;
	}
	public void getHit(){
		lives--;
		if (lives <= 0) {
			die ();
		}


	}
}
