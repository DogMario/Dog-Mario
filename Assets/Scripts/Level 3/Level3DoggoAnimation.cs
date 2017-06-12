using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DoggoAnimation : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Vertical") != 0) {
            anim.SetBool("Walking", true);
        }
        else {

            anim.SetBool("Walking", false);
        }

	}
}
