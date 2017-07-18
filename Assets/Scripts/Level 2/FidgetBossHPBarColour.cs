using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FidgetBossHPBarColour : MonoBehaviour {

    private FidgetBossMainScript fbMain;
    private Image image;
    private bool isRed;

	// Use this for initialization
	void Start () {
        fbMain = GetComponentInParent<FidgetBossMainScript>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(fbMain.hp <= fbMain.threshold && !isRed) {
            var red = new Color32(255, 0, 0, 150);
            image.color = red;
            isRed = true;
        }
	}
}
