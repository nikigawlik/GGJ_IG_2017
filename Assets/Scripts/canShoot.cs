using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canShoot : MonoBehaviour {

	public GameObject BulletPrefab;
	public Camera cam;
	float timer;

	public string feuerButton;

	//Vector3 bulletSpeed;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButtonDown(feuerButton) && timer > 1) {
			//Rotation doesnt work for some reason *~*
			GameObject bullet = Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
			//Direction:
			bullet.GetComponent<BulletController> ().speed = this.transform.rotation * Vector3.right;
			bullet.GetComponent<BulletController> ().cam = this.cam;
			timer = 0;

		
		}

	}
}
