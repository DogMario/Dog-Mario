using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLivesText : MonoBehaviour {

    Text livesText;

    void Awake() {
        livesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        livesText.text = "X " + StaticLives.lives.ToString();
    }
}
