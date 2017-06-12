using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInputRotation : MonoBehaviour {

    public float turningSpeed = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
    }
}
