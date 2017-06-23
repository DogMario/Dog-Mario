using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	//Kills player if collision occurs
	void OnTriggerEnter2D(Collider2D other) {

		if ((tag == "Spike" || tag == "KillPlayer") && (other.tag == "Player" || other.tag == "DogHead")) {

            // use this to test collision without dying, otherwise comment it out
            // Debug.Log("kill");	

            // actual death
            other.GetComponentInParent<PlayerController> ().Die ();

		} 

	}
}
