using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeDestroyed : MonoBehaviour {

    public bool destroysLaserToo = true;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "DogFeet") {
            if (destroysLaserToo) {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
