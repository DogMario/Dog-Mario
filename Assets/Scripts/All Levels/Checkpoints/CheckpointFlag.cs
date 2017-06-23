using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour {

    public int checkpointNum;

	// Use this for initialization
	void Start () {
        if (StaticCheckpoint.checkpoint >= checkpointNum) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(StaticCheckpoint.checkpoint < checkpointNum && other.tag == "Player") {
            //when player passes this flag, set checkpoint to this flag's checkpoint number, then disable this flag
            StaticCheckpoint.checkpoint = checkpointNum;
            Destroy(gameObject);
        }
    }
}
