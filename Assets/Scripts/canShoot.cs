﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canShoot : MonoBehaviour {

	public GameObject BulletPrefab;
	public Camera cam;
	float timer;
	Animator anim;

	public AudioClip[] shootSound = new AudioClip[3];
	public AudioSource mySauce;

	private string shootButton;
	public string keyboardShootKey = "left ctrl";

	//Vector3 bulletSpeed;
	// Use this for initialization
	void Start () {
		mySauce = GetComponentInParent<AudioSource> ();

		anim = GetComponentInParent<Animator> ();
		WaveSurf surf = GetComponentInParent<WaveSurf> ();

		shootButton = "joystick " + surf.gamepad + " button 1";
		//Debug.Log (shootButton);
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((Input.GetKeyDown(shootButton) || Input.GetKeyDown(keyboardShootKey)) && timer > 1) {
			//Rotation doesnt work for some reason *~*
			anim.SetTrigger("shoot");
			mySauce.clip = shootSound[Random.Range(1,3)];
			mySauce.Play ();
			GameObject bullet = Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
			//Direction:
			bullet.GetComponent<BulletController> ().speed = this.transform.rotation * Vector3.right;
			bullet.GetComponent<BulletController> ().cam = this.cam;
			timer = 0;

		
		}

	}
}
