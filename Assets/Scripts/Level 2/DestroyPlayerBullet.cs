using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerBullet : MonoBehaviour {
        //destroys bullets
        public void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "DogFeet") {
                Destroy(other.gameObject);
            }
        }
    }
