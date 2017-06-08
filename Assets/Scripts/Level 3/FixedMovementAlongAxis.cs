using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAlongAxis : MonoBehaviour {

    public char moveAlong = 'Z';
    public float period;
    public float speed;
    private GameObject player;

    private float startTime;
    public bool playerOn;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player = other.gameObject;
            playerOn = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player" ) {
            playerOn = false;
        }
    }

    // Update is called once per frame
    void Update () {
        switch (moveAlong) {
            case 'X':
                transform.position += (new Vector3(Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period),0, 0) * speed) * Time.deltaTime;
                if (playerOn) {
                    player.transform.position += (new Vector3(Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period), 0, 0) * speed) * Time.deltaTime;
                }
                break;
            case 'Z':
                transform.position += (new Vector3(0,0,Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period)) * speed) * Time.deltaTime;
                if (playerOn) {
                    player.transform.position += (new Vector3(0, 0, Mathf.Cos((Time.time - startTime) * (2 * Mathf.PI) / period)) * speed) * Time.deltaTime;
                }
                break;
            default:
                Debug.Log("moving tile wrong axis?");
                break;
        }
        if (player != null && Mathf.Abs(player.transform.position.x - transform.position.x) < 2f && Mathf.Abs(player.transform.position.z - transform.position.z) < 2f
                            && (player.transform.position.y - transform.position.y) < 1.0f && (player.transform.position.y - transform.position.y) > 0.6f){
            playerOn = true;
        }
        else if (player != null && (Mathf.Abs(player.transform.position.x - transform.position.x) > 2f || Mathf.Abs(player.transform.position.z - transform.position.z) > 2f)) {
            playerOn = false;
            player = null;
        }
    }
}
