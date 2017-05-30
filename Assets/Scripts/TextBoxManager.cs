using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine; //where the script is currently reading
	public int endAtLine; //where the script ends

	public PlayerController player;

	public bool isActive; // 

	// when dialogue starts, player movement stops
	public bool stopPlayerMovement;

	// Use this for initialization
	void Start () {

		// Find player object reference
		player = FindObjectOfType<PlayerController> ();

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}


		// DEFAULT - if endAtLine = 0, end at end of file
		if (endAtLine == 0) 
			endAtLine = textLines.Length - 1;

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!isActive)
			return;

		theText.text = textLines [currentLine]; //get current text line

		if (Input.GetKeyDown (KeyCode.Space)) {
			currentLine += 1;
		}

		if (currentLine > endAtLine) {
			DisableTextBox ();
			isActive = false;
	}
	}

	public void EnableTextBox() {
		textBox.SetActive (true); // open dialogue

		if (stopPlayerMovement) 
			player.canMove = false; // stops player control

	}

	public void DisableTextBox() {
		textBox.SetActive (false); // close dialogue
		player.canMove = true; // let player move
	}
}
