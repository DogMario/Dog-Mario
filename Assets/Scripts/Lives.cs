using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public int lives = 3;
    Text livesText;

    void Awake() {
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "X " + lives.ToString();
	}
}
