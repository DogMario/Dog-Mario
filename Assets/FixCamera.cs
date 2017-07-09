using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCamera : CameraController {

    private GameObject fallingCam;
    public Vector3 camPos;
    public bool isGoingToFall = false;
    public GameObject mainCamera;
    public GameObject vertCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isGoingToFall = true;
            fallingCam = vertCamera;
            fallingCam.SetActive(true);
            mainCamera.SetActive(false);
           
            fallingCam.transform.position = camPos;
        }
    }

    // Use this for initialization
    void Start () {
        fallingCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
