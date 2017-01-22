using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasPoints : MonoBehaviour {

	[HideInInspector] public int points;

	void Start () {
		points = 0;
	}

	public void increasePoints(){
		points++;
		Debug.Log ("psasdfodi");
	}
}
