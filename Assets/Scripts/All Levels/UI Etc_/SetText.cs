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
        else if (output.Equals("CurrLivesLost"))
            text.text = "current lives lost\n" + StaticLives.currLost;
        else if (output.Equals("MinLivesLost")) {
            if (StaticLives.minLost == int.MaxValue)
                text.text = "minimum lives lost\n" + "--";
            else
                text.text = "minimum lives lost\n" + StaticLives.minLost;
            if (StaticLives.minLost == 0)
                text.color = new Color32(255, 255, 160, 255);
            else
                text.color = new Color32(255, 255, 255, 255);
        }       
	}
}
