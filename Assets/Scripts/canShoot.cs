using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canShoot : MonoBehaviour {

	public GameObject BulletPrefab;
	public Camera cam;
	float timer;
	Animator anim;

	private string shootButton;
	public string keyboardShootKey = "left ctrl";

    private WaveSurf surf;

    //Vector3 bulletSpeed;
    // Use this for initialization
    void Start () {
		anim = GetComponentInParent<Animator> ();
		 surf = GetComponentInParent<WaveSurf> ();

		
	}
	
	// Update is called once per frame
	void Update () {

        shootButton = "joystick " + surf.GetGamePad() + " button 1"; // hacks :D
        timer += Time.deltaTime;
		if ((Input.GetKeyDown(shootButton) || Input.GetKeyDown(keyboardShootKey)) && timer > 1) {
			//Rotation doesnt work for some reason *~*
			anim.SetTrigger("shoot");
			GameObject bullet = Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
			//Direction:
			bullet.GetComponent<BulletController> ().speed = this.transform.rotation * Vector3.right;
			bullet.GetComponent<BulletController> ().cam = this.cam;
			timer = 0;

		
		}

	}
}
