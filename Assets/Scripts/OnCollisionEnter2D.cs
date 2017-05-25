using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnter2D : MonoBehaviour {



	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "IgnoreCollision") {
			Physics.IgnoreCollision (collision.collider, GetComponent<Collider>());
		}


	}
}
