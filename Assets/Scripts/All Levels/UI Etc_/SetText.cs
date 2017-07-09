using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    public string output;
    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (output.Equals("Music"))
            text.text = StaticVolume.staticMusicVol.ToString();
        else if (output.Equals("SFX"))
            text.text = StaticVolume.staticSFXVol.ToString();
	}
}
