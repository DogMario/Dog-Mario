using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuMinLivesText : MonoBehaviour {

    public string levelName;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (!PlayerPrefs.HasKey(levelName) || PlayerPrefs.GetInt(levelName) == int.MaxValue)
            text.text = "Minimum lives lost: " + "--";
        else
            text.text = "Minimum lives lost: " + PlayerPrefs.GetInt(levelName);
        if (StaticLives.minLost == 0)
            text.color = new Color32(255, 255, 160, 255);
        else
            text.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Backslash)) {    // press \ to delete ALL saved score
            PlayerPrefs.DeleteAll();
            text.text = "Minimum lives lost: " + "--";
        }
    }
}
