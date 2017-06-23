using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool follow;
    public GameObject player;
    public PlayerController playerController;
    public float leftEnd;   //past this x value the camera starts following player
    public float rightEnd;  //past this x value the camera stops folloing player
    float yValue;    //constant y value for camera in side scrolling levels

	// Use this for initialization
	void Start () {
        follow = false;
        yValue = 3.5f;
        playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x < leftEnd || player.transform.position.x > rightEnd) {
            follow = false;
        }
        else {
            follow = true;
        }
        if(playerController.isGrounded()) {
            if (player.transform.position.y > 4.0f) {
                yValue = Mathf.Min(player.transform.position.y -1.0f, 8.0f);
            }
            else if(player.transform.position.y < -2.0f) {
                yValue = 1.0f;
            }
            else {
                yValue = 3.5f;
            }
        }
        else if(player.transform.position.y < yValue - 8.0f) {
            yValue -= 8.0f;
            yValue = Mathf.Max(3.5f, yValue);
        }
        else if(playerController.getSpeed().y < -4.0f) {
            yValue -= 1.0f;
            yValue = Mathf.Max(3.5f, yValue);
        }
	}

    void FixedUpdate() {
        if (follow) {
            transform.position = Vector3.Lerp(transform.position,new Vector3(player.transform.position.x, yValue, -0.3f), 5 * Time.deltaTime);
        }
        else {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yValue, -0.3f), 5* Time.deltaTime);
        }
    }

}
