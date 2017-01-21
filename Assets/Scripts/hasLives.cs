using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasLives : MonoBehaviour {

	public int lives;

	void die(){
		//respawn
		// fixed this -Nils ;)
		Vector2 pos = transform.position;
		pos.x = 0;
		transform.position = pos;
	}
	void getHit(){
		lives--;
		if (lives <= 0) {
			die ();
		}


	}
}
