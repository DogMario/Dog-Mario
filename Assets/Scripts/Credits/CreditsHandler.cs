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
		
	}
}
