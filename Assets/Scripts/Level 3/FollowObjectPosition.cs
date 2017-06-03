using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
	}
}
