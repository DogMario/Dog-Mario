using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetBossSubMovement : MonoBehaviour {

    public float rotationCD = 1f;
    public float rotationSpeed = 5f;
    private float nextRotation;

    private Quaternion newRotation;

	// Use this for initialization
	void Start () {
        nextRotation = Time.time;
        newRotation = Quaternion.Euler(0, 0, Random.Range(-45, 45));
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextRotation + rotationCD) {
            //if past cooldown, update cooldown time and set new target rotation
            nextRotation = Time.time;
            newRotation = Quaternion.Euler(0, 0, Random.Range(-50, 60));
        }
        //slerp towards target rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation , Time.deltaTime * rotationSpeed);
    }
}
