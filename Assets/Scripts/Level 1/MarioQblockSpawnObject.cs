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
    //EdgeCollider2D ec2D;
    AudioSource getHit;

	// Use this for initialization
	void Start () {
        //ec2D = GetComponent<EdgeCollider2D>();
        /*if (invisible) {
            ec2D.isTrigger = false;
        }*/
        getHit = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (invisible) {
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("Invis", true);
        }
    }
	
    void OnTriggerEnter2D(Collider2D c) {
        if (c.tag == "DogFeet") {
            StartCoroutine(EnterAfter(0.1f));
            StartCoroutine(ExitAfter(0.75f));
        }
        if (c.tag == "DogHead" && !broken && c.GetComponentInParent<Transform>().transform.position.y < transform.position.y - 1f && !entered) {
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

    IEnumerator EnterAfter(float f) {
        yield return new WaitForSeconds(f);
        entered = true;
    }

    IEnumerator ExitAfter(float f) {
        yield return new WaitForSeconds(f);
        entered = false;
    }

    /*void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "DogHead") {
            entered = false;
        }
    }*/
}
