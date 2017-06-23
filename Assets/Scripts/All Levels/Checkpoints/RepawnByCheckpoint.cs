using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepawnByCheckpoint : MonoBehaviour {

    public GameObject[] checkpoints;
    //an array of gameobjects, drag every flag into this script componenet
    
	// Use this for initialization
	void Start () {
        if (StaticCheckpoint.checkpoint > 0) {  //if a checkpoint has been passed, the position of the object that this script is attached to (i.e. doggo)
                                                //will be at the place of the passed checkpoint
            transform.position = checkpoints[StaticCheckpoint.checkpoint - 1].transform.position;
        }
	}
}
