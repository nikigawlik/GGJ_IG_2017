﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {


    public void StartGame (string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }
}
