using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonController : MonoBehaviour {



	public GameObject thor1;
	public GameObject thor2;

	public GameObject[] players = new GameObject[4];
	private GameObject firstPlayer;

	public GameObject coinPrefab;

	public int maxCoins;
	public int coinsPerFrame;
	private GameObject[] coins;
	private bool coinArrayFilled;
	private int coinsCreatedThisFrame;


	void Start(){
		coins = new GameObject[maxCoins];
		coinArrayFilled = false;
//		for (int counter = 0; counter < coins.Length; counter++) {
//			coins[counter] = Instantiate (coinPrefab, thor1.transform.position, this.transform.rotation);
//		}

	}

	// Update is called once per frame
	void Update (){
		//Determine player most right
		float highScore = 0;
		foreach (GameObject player in players) {
			if (highScore < player.transform.position.x) {
				highScore = player.transform.position.x;
				firstPlayer = player;
			}
		}
	}


	void FixedUpdate () {
		if (coinArrayFilled == false) {
			for (int counter = 0; counter < coins.Length; counter++) {
				if (coins [counter] == null && coinsCreatedThisFrame < coinsPerFrame) {
					coinsCreatedThisFrame++;
					coins [counter] = Instantiate (coinPrefab, thor1.transform.position, this.transform.rotation);
					coins [counter].GetComponent<coinController> ().coinVelocity = new Vector3 (Random.Range (-0.01f, -0.7f),Random.Range (-0.01f, -0.7f), 0f);
				} else if (coinsCreatedThisFrame >= coinsPerFrame) {
					break;
				}
			}
		}
		coinsCreatedThisFrame = 0;


		for (int counter = 0; counter < coins.Length; counter++) {
			if (coins [counter] != null) {
				coins [counter].gameObject.GetComponent<MeshRenderer> ().material.color = firstPlayer.GetComponent<SpriteRenderer> ().color;

				Vector3 move = (firstPlayer.transform.position - coins [counter].transform.position);
				move.Normalize ();
				coins [counter].GetComponent<coinController> ().moveCoin (move);
			

				if (Vector3.Distance (coins [counter].transform.position, firstPlayer.transform.position) <= 1) {
					Destroy (coins [counter]);
				}
			}
		}
		//Head Movement
		thor1.transform.position = new Vector2(thor1.transform.position.x , (float) (0.5 * Mathf.Sin ((float)(1 * Time.time)) + 3.5 ));
		thor2.transform.position = new Vector2(thor1.transform.position.x , (float) (-0.5 * Mathf.Cos ((float)(1 * Time.time)) - 3.5 ));
	}
}
