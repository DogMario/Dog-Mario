using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public bool randomise;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (randomise) {
            rb.velocity = transform.right * Random.Range(speed - 2.0F, speed + 2.0F);
        }
        else {
            rb.velocity = transform.right * speed;
        }
    }
}
