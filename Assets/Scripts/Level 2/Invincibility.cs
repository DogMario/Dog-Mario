using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
