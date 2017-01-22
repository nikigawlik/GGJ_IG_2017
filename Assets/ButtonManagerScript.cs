using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {

    bool moveAnim = false;

    public Vector2 newCompPos;
    public Vector2 newVikingPos;

    GameObject firstButton;
    GameObject computer;
    GameObject titleViking;

    void Start() {
        firstButton = GameObject.Find("FirstButton");
        computer = GameObject.Find("Computer");
        titleViking = GameObject.Find("TitleVinking");
    }

    void Update()
    {
        if (moveAnim)
        {
            computer.GetComponent<RectTransform>().transform.localPosition = Vector2.Lerp(computer.GetComponent<RectTransform>().transform.localPosition, newCompPos, 0.2f);
            titleViking.GetComponent<RectTransform>().transform.localPosition = Vector2.Lerp(titleViking.GetComponent<RectTransform>().transform.localPosition, newVikingPos, 0.2f);
        }
    }

    public void SecondScreen()
    {
        moveAnim = true;
        firstButton.gameObject.SetActive(false);
    }


    public void StartGame (string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
