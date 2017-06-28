using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLerpPositions : MonoBehaviour {

    public Vector3 endPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lerp airman = transform.parent.GetComponent("Lerp") as Lerp;

        if (collision.tag == "KillPlayer" && !airman.isEnabled)
        {
            airman.startPos = airman.movingObj.transform.position;
            airman.startPos = airman.endPos;
            airman.endPos = endPos;
            airman.isEnabled = true;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
