using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownControl : MonoBehaviour {

	private dragonController dg;
	public 	Vector2 offset = new Vector2 (0f, .6f);

	// Use this for initialization
	void Start () {
		GameObject dragons = GameObject.Find ("Dragons");
		dg = dragons.GetComponent<dragonController> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject fp = GetBestPlayer ();
		float lerp = 0.5f;
		transform.position = Vector3.Lerp (transform.position, fp.transform.position + fp.transform.TransformVector(offset), lerp);
		transform.rotation = Quaternion.Lerp (transform.rotation, fp.transform.rotation, lerp);
	}

	GameObject GetBestPlayer() {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		int maxScore = -1;
		GameObject retVal = null;
		foreach (GameObject p in players) {
			hasPoints pComp = p.GetComponent<hasPoints> ();
			if (pComp.points > maxScore) {
				maxScore = pComp.points;
				retVal = p;
			}
		}
		return retVal;
	}
}
