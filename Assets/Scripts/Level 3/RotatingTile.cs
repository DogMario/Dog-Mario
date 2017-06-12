using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTile : MonoBehaviour {

    public bool clockwise;
    public float rotationSpeed = 100f;
    public char rotateAround = 'Z';

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ax;
        switch (rotateAround) {
            case 'X':
                ax = new Vector3(1, 0, 0);
                break;
            case 'Y':
                ax = new Vector3(0, 1, 0);
                break;
            case 'Z':
                ax = new Vector3(0, 0, 1);
                break;
            default:
                ax = new Vector3(0, 0, 0);
                break;
        }
        if (clockwise) {
            transform.Rotate(ax, Time.deltaTime * rotationSpeed);
        }
        else {
            transform.Rotate(ax, Time.deltaTime * -rotationSpeed);
        }
    }
}
