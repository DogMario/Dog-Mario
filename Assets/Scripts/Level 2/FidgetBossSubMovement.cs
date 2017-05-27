using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetBossSubMovement : MonoBehaviour {

    public float rotationCD = 0.5f;
    public float rotationSpeed = 5f;
    private float nextRotation;
    private FidgetBossMainScript mainScript;

    private Quaternion newRotation;

	// Use this for initialization
	void Start () {
        nextRotation = Time.time;
        mainScript = GetComponentInParent<FidgetBossMainScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextRotation + rotationCD && (mainScript.toSmirk || mainScript.toThankful)) {
            //if past cooldown, update cooldown time and set new target rotation
            nextRotation = Time.time;
            newRotation = Quaternion.Euler(0, 0, Random.Range(-55, 45));
        }
        if(Time.time > nextRotation + rotationCD && mainScript.toDiao) {
        
            
            if (Time.time < mainScript.diaoStart + mainScript.laserDelay) {
                newRotation = Quaternion.LookRotation(mainScript.player.transform.position - GetComponentInParent<Transform>().position) * Quaternion.Euler(0,0,-10);
            }
            else {
                
            }
        }
        //slerp towards target rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation , Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "DogFeet") {
            mainScript.hp--;
        }
    }
}
