using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceY : MonoBehaviour {

    public float bounceForce = 1f;
    //to improve: make it dependent of other's velocity?

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, bounceForce /**  other.GetComponent<Rigidbody>().velocity.y*/,0)) ;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
