using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script to move right
// for: projectiles, normal enemies
public class SimpleMoveRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * Time.deltaTime);
	}
}
