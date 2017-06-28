using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour {

    // insert object to move
    public GameObject movingObj;

    // bool to control movement
    public bool isEnabled = false;

    // start/end pos and distance
    public Vector3 startPos;
    public Vector3 endPos;
    //public float distance = 30f;
    //public Vector3 direction;

    // Time taken from start to end
    private float lerpTime = 5;

    // updates current Lerp time
    private float currentLerpTime = 0;

	// Use this for initialization
	void Start () {
        startPos = movingObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;
            movingObj.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }

        if (movingObj.transform.position == endPos)
        {
            isEnabled = false;
        }
	}
}
