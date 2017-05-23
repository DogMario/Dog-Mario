using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	//Kills player if collision occurs
	void OnTriggerEnter2D(Collider2D other) {
		if (tag == "KillPlayer" && (other.tag == "Player" || other.tag == "DogHead")) {

			other.GetComponentInParent<PlayerController>().Die();
		}

	}
}
