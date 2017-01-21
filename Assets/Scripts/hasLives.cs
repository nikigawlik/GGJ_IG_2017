using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasLives : MonoBehaviour {

	public int lives;

	void die(){
		//respawn
		this.transform.position.x = 0;
	}

	void getHit(){
		lives--;
		if (lives <= 0) {
			die ();
		}


	}
}
