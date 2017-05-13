using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlive : MonoBehaviour {
	//true = alive, false = dead
	public bool alive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alive == false) {
			Destroy (gameObject);
			print ("test");
		}
	}

	public void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "KillPlayer")
			alive = false;
	}
}
