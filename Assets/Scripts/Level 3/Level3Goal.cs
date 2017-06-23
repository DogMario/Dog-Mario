using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Goal : MonoBehaviour {

    private Animator anim;
    public static bool passed;  //check if goal reached. access by calling Level3Goal.passed.

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        passed = false;
	}
	
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            anim.SetTrigger("Passed");
            passed = true;
        }
    }
}
