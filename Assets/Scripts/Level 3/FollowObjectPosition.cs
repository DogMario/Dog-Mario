using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour {

    public GameObject target;
    public float waitTime = 0.1f;
    private bool follow;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null && Time.time > startTime + waitTime) {
            transform.position = target.transform.position;
        }
	}
}
