using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other) {
        /*if(other.tag == "Player") {
            other.GetComponent<Level2PlayerController>().Die();
        }
        else {*/
            Destroy(other.gameObject);
        //}
    }
}
