using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

	public TextAsset textFile; //txt file to input text
	public string[] textLines; //store dialogue into array textLines

	// Use this for initialization
	void Start () {

		// if there's a textfile,
		// stores each line into a different entry of the array
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n')); 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
