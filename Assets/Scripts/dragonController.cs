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
	private Vector3 move;
	public int coinsPerHead;
	private int createdAtThor1;
	private bool creatingAtThor2;

	void Start(){
		coinsPerHead = maxCoins;
		firstPlayer = players[0];
		coins = new GameObject[maxCoins];
		coinArrayFilled = false;
//		//Fill beforeHand!
//		for (int counter = 0; counter < coins.Length; counter++) {
//			coins[counter] = Instantiate (coinPrefab, thor1.transform.position, this.transform.rotation);
//		}

	}

	void Update (){
		//Determine player most right
		for (int x = 0; x < 4; x++) {
			if (firstPlayer.transform.position.x <= players [x].transform.position.x) {
				firstPlayer = players [x];
			}

//			Debug.Log (firstPlayer);
			for (int counter = 0; counter < coins.Length; counter++) {
				if (coins [counter] != null) {


					if (Vector3.Distance (coins [counter].transform.position, firstPlayer.transform.position) <= .5) {
						Destroy (coins [counter]);
						Debug.Log ("hihihihihi");
						firstPlayer.GetComponent<hasPoints> ().increasePoints ();
					}
					coins [counter].gameObject.GetComponent<MeshRenderer> ().material.color = firstPlayer.GetComponent<SpriteRenderer> ().color;
				}
			}
		}

	}


	void FixedUpdate () {
		if (coinArrayFilled == false) {
			for (int counter = 0; counter < coins.Length; counter++) {
				if (coins [counter] == null && coinsCreatedThisFrame < coinsPerFrame) {
					coinsCreatedThisFrame++;

					if (createdAtThor1 >= coinsPerHead)
						creatingAtThor2 = true;
					else if (createdAtThor1 <= 0) {
						creatingAtThor2 = false;
					}

					if (creatingAtThor2 == false) {
						coins [counter] = Instantiate (coinPrefab, thor1.transform.position, this.transform.rotation);
						createdAtThor1++;
						coins [counter].GetComponent<coinController> ().coinVelocity = new Vector3 (Random.Range (-0.01f, -0.2f),Random.Range (0.2f, 0.7f), 0f);
					} else if (creatingAtThor2 == true) {
						coins [counter] = Instantiate (coinPrefab, thor2.transform.position, this.transform.rotation);
						createdAtThor1--;
						coins [counter].GetComponent<coinController> ().coinVelocity = new Vector3 (Random.Range (-0.01f, -0.2f),Random.Range (-0.2f, -0.7f), 0f);
					}


				} else if (coinsCreatedThisFrame >= coinsPerFrame) {
					break;
				}
			}
		}
		coinsCreatedThisFrame = 0;


		for (int counter = 0; counter < coins.Length; counter++) {
			if (coins [counter] != null) {
				
				move = ( firstPlayer.transform.position - coins [counter].transform.position );
				move.Normalize ();
				coins [counter].GetComponent<coinController> ().moveCoin (move);
			}
		}
		//Head Movement
		thor1.transform.position = new Vector2(thor1.transform.position.x , (float) (0.5 * Mathf.Sin ((float)(1 * Time.time)) + 3.5 ));
		thor2.transform.position = new Vector2(thor1.transform.position.x , (float) (-0.5 * Mathf.Cos ((float)(1 * Time.time)) - 3.5 ));
	}
}
