using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    //will cue a pause menu in the future. for now, quit game
    //Application.Quit() only works outside of unity editor. i.e. need to build and run to see it work
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
