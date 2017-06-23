using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DoggoRotationRegulator : MonoBehaviour {

    public float turningSpeed = 120;

    public bool faceBack;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!Level3Goal.passed) {
            if (Input.GetAxis("Vertical") < 0) {
                //transform.RotateAround(transform.position, Vector3.up, 180);
                //transform.Rotate(0, 180, 0);
                transform.eulerAngles = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y - 85, 0);
                faceBack = true;
            }
            else if (Input.GetAxis("Vertical") > 0) {
                //transform.RotateAround(transform.position, Vector3.up, 180);
                //transform.Rotate(0, 180, 0);
                transform.eulerAngles = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y + 180 - 85, 0);
                faceBack = false;
            }
            float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
            transform.Rotate(0, faceBack ? -horizontal : horizontal, 0);
        }
    }

    void LateUpdate() {
        Mathf.Clamp(transform.rotation.x, 0, 0);
        Mathf.Clamp(transform.rotation.z, 0, 0);
        /*if (faceBack) {
            Mathf.Clamp(transform.rotation.y, 180, 360);
        }
        else {
            Mathf.Clamp(transform.rotation.y, 0, 180);
        }*/
        if (!faceBack) {
            Mathf.Clamp(transform.localEulerAngles.y, Camera.main.transform.rotation.eulerAngles.y - 170, Camera.main.transform.rotation.eulerAngles.y);
        }
        else {
            Mathf.Clamp(transform.localEulerAngles.y, Camera.main.transform.rotation.eulerAngles.y + 10, Camera.main.transform.rotation.eulerAngles.y + 260);
        }
    }
}

