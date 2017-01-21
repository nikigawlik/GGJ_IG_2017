using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour {

    int[] joystickIds;
    public GameObject[] players;

	// Use this for initialization
	void Start () {
        GameObject o = GameObject.FindGameObjectWithTag("GamepadData");

        if (o == null)
            return;


        joystickIds = o.GetComponent<listenForGamepads>().GetJoystickIds();
        GameObject.Destroy(o);

        for (int i = 0; i < 4; i++)
        {
            if (joystickIds[i] <= 0)
                GameObject.Destroy(players[i]);
            players[i].GetComponent<WaveSurf>().SetGamepadId(joystickIds[i]);
            Debug.Log(i);
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 1; i < 12; i++)
        {
            if (Input.GetKeyDown("joystick " + i + " button 0"))
                Debug.Log(i);
        }
    }
}
