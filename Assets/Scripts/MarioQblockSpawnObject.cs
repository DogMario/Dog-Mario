using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioQblockSpawnObject : MonoBehaviour {

    public GameObject objectToSpawn;
    public bool invisible;
    Animator anim;
    bool broken;
    bool entered;
    SpriteRenderer[] sprites;
    bool moved;
    EdgeCollider2D ec2D;
    AudioSource getHit;

    void Awake() {
        ec2D = GetComponent<EdgeCollider2D>();
        if (invisible) {
            ec2D.isTrigger = false;
        }
        getHit = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (invisible) {
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("Invis", true);
        }
    }
	
    void OnTriggerEnter2D(Collider2D c) {
        if (c.tag == "DogFeet" || c.tag == "Player") {
            entered = true;
        }
        if (c.tag == "DogHead" && !broken && c.transform.position.y < transform.position.y - 0.2f && !entered) {
            GetComponent<BoxCollider2D>().enabled = true;
            getHit.Play();
            anim.SetBool("Invis", false);
            anim.SetTrigger("Broke");
            

            if (objectToSpawn != null) {
                Instantiate(objectToSpawn, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            }

            broken = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "DogHead") {
            entered = false;
        }
    }

    /*void LateUpdate() {
        if (broken && !moved) {
            //transform.localPosition += new Vector3(startPosition.x, -startPosition.y,0f);
            transform.localPosition += startPosition;
            moved = true;
        }
    }*/
}
