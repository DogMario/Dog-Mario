using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	// new starting and end points
	public int startLine;
	public int endLine;

	public TextBoxManager textBoxManager;

	public bool allTextRead;

	// Use this for initialization
	void Start () {
		textBoxManager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			textBoxManager.ReloadScript (theText);
			textBoxManager.currentLine = startLine;
			textBoxManager.endAtLine = endLine;
			textBoxManager.EnableTextBox ();

			if (allTextRead)
				Destroy (gameObject);
		}
	}
}
