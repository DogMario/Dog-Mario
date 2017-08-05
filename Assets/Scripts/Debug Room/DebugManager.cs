using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
            if (PlayerPrefs.HasKey("Cleared 1"))
                PlayerPrefs.DeleteKey("Cleared 1");
            else
                PlayerPrefs.SetInt("Cleared 1", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
            if (PlayerPrefs.HasKey("Cleared 2"))
                PlayerPrefs.DeleteKey("Cleared 2");
            else
                PlayerPrefs.SetInt("Cleared 2", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
            if (PlayerPrefs.HasKey("Cleared 3"))
                PlayerPrefs.DeleteKey("Cleared 3");
            else
                PlayerPrefs.SetInt("Cleared 3", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
            if (PlayerPrefs.HasKey("Cleared 4"))
                PlayerPrefs.DeleteKey("Cleared 4");
            else
                PlayerPrefs.SetInt("Cleared 4", 1);
        }
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            PlayerPrefs.DeleteAll();
        }
    }
}
