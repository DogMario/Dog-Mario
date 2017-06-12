using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedVerticalMovement : MonoBehaviour {

    public float period = 1;    //time to finish going down n up (two cycles, or 2 pi)
    public float speed;
    private GameObject player;

    private float startTime;
    public bool playerOn;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        player = null;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player = other.gameObject;
            playerOn = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            if (Mathf.Cos(Time.time - startTime) > 0) {
                playerOn = false;
            }
        }
    }

    void FixedUpdate() {
        transform.position += (new Vector3(0, Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period), 0) * speed) * Time.deltaTime;
        if (playerOn) {
            Camera.main.transform.position += (new Vector3(0, Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period), 0) * speed) * Time.deltaTime;
            player.transform.position += (new Vector3(0, Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period), 0) * speed) * Time.deltaTime;
        }
        if (player != null && Mathf.Abs(player.transform.position.x - transform.position.x) < 2f && Mathf.Abs(player.transform.position.z - transform.position.z) < 2f
                            && (player.transform.position.y - transform.position.y) < 1.0f && (player.transform.position.y - transform.position.y) > 0.6f) {
            playerOn = true;
        }
        else if(player != null &&(Mathf.Abs(player.transform.position.x - transform.position.x) > 2f || Mathf.Abs(player.transform.position.z - transform.position.z) > 2f)) {
            playerOn = false;
            player = null;
        }
    }
}
