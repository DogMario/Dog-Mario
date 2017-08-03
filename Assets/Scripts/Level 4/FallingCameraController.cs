using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCameraController : MonoBehaviour {

    public GameObject player;
    public PlayerController playerController;
    public Vector3 camPos;


    private bool isMainCamera = false;
    
    // Use this for initialization
    void Start () {
        playerController = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!this.enabled)
            return;

        else
        {
            isMainCamera = true;
        }

        if (isMainCamera)
        {
            transform.position = camPos;
        }
	}
}
