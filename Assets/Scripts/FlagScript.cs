using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
    
    float currentTime = 0f;
    float timeToMove = 10f;

    private GameObject flag;
    private bool reached;

    void Start() {
        flag = GameObject.Find("Flag");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" || other.tag == "DogFeet" || other.tag == "DogHead") {
            other.GetComponentInParent<PlayerController>().ReachFlag();
            reached = true;
        }
    }

    void Update() {
         if (reached){
            if (currentTime <= timeToMove) {
                currentTime += Time.deltaTime;
                flag.transform.position = Vector2.Lerp(flag.transform.position, new Vector2(flag.transform.position.x, -5f), currentTime / timeToMove);
            }
            else {
                reached = false;
            }
        }
    }
}
