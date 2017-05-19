using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2KillPlayer : MonoBehaviour {
    //Kills player if collision occurs
    public void OnTriggerEnter2D(Collider2D other) {
        if (tag == "KillPlayer" && other.tag == "Player") {
            other.GetComponentInParent<Level2PlayerController>().Die();
        }
    }
}

