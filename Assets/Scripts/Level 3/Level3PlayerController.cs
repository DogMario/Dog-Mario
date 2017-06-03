using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlayerController : MonoBehaviour {
    public float movementSpeed = 10;
    public float turningSpeed = 60;
    private Rigidbody rb;
    private float lastY;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        rb.AddForce(Camera.main.transform.forward * vertical);
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * 0.5f * Time.deltaTime;
        rb.AddForce(Camera.main.transform.right * horizontal);
    }
}