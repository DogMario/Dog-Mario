using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinLivesInit : MonoBehaviour {

	// Use this for initialization
	void Update () {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name)) {
            StaticLives.minLost = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
        }
        else
            StaticLives.minLost = 999;

        if (Input.GetKey(KeyCode.Backslash))    // press \ to delete ALL saved score
            PlayerPrefs.DeleteAll();
    }
}
