using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour {

	public int rank;
	public GameObject player;

	public int pointsToWin = 1000;

	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		image.color = player.GetComponent<SpriteRenderer> ().color;
	}

	
	// Update is called once per frame
	void Update () {
		hasPoints hp = player.GetComponent<hasPoints>();
		image.fillAmount = (float)hp.points / (float)pointsToWin;
	}
}
