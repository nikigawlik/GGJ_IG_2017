using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasLives : MonoBehaviour {

	public int lives;
	public Camera cam;

	public AudioSource mySauce;
	public AudioClip getHitSound;
	void Start(){
		mySauce = GetComponent<AudioSource> ();
	}

	void die(){
		//respawn
		// fixed this -Nils ;)
		Vector2 pos = transform.position;
		pos.x = (float) (-cam.orthographicSize * cam.aspect + 0.4 );
		transform.position = pos;
	}
	public void getHit(){
		mySauce.clip = getHitSound;
		mySauce.Play ();

		lives--;
		if (lives <= 0) {
			die ();
		}


	}
}
