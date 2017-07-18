using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FidgetBossHPBarSlider : MonoBehaviour {

    private Slider slider;
    private FidgetBossMainScript fbMain;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        fbMain = GetComponentInParent<FidgetBossMainScript>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = fbMain.hp;
	}
}
