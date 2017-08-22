using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int i = 1;
		while(PlayerPrefs.HasKey("Cleared " + i)) {
            PlayerPrefs.DeleteKey("Cleared " + i);
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
                          Application.Quit();
#endif
        }
    }
}
