using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugClearedText : MonoBehaviour {

    private Text text;
    public int number;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PlayerPrefs.HasKey("Cleared " + number) ? "" + number + " cleared" : "" + number + " not cleared";
	}
}
