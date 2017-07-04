using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosionsHere2D : MonoBehaviour {

    public GameObject firework;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other) {
        if(other.tag == "Player") {
            InvokeRepeating("Explode", 0.5f, 0.3f);
        }
    }

    void Explode() {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-6, 6), transform.position.y +  Random.Range(-5, 15), 0);
        Instantiate(firework, position, new Quaternion(0, 0, 0, 0));
    }
}
