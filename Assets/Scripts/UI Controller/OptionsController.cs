﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
