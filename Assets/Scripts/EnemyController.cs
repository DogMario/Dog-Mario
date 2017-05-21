using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public bool move1Way;
    public bool moveLeft = true;
    public float speed;
    Rigidbody2D rb2D;
    Animator anim;
    bool isDead;
    AudioSource getHit;
    //float startTime;
    //float bufferTimeStart = 0f;
    //float threshold = 0.03f;
    //bool justChanged;
    //bool timeStarted;
    //Vector3 offset;
    //Vector3 lastPos;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        getHit = GetComponent<AudioSource>();
        if (!move1Way) {
            StartCoroutine(RandomMovement());
        }
        //startTime = Time.time;
        //lastPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < -8.0f && !isDead) {
            Die();
        }
        /*if (move1Way && rb2D.velocity.magnitude < 1.5f && Time.time - startTime > 1.0f) {
            Debug.Log("changeDir");
            moveLeft = !moveLeft;
        }*/
        /*if(rb2D.velocity.magnitude < 10f) {
            Debug.Log("<10");
        }
        if(rb2D.velocity.magnitude < 1f) {
            Debug.Log("<1");
        }*/
       /*if (move1Way && Time.time - startTime>5.0f) {
            offset = transform.position - lastPos;
            Debug.Log(offset.x);
            if(offset.x < threshold && !timeStarted) {
                bufferTimeStart = Time.time;
                timeStarted = true;
            }
            if(Mathf.Abs(offset.x) > (threshold)) {
                lastPos = transform.position;
                justChanged = false;
                timeStarted = false;
            }
            else if(timeStarted && bufferTimeStart > 1.5f){
                lastPos = transform.position;
                moveLeft = !moveLeft;
                Debug.Log("changed");
                justChanged = true;
                timeStarted = false;
            }
            //lastPos = transform.position;
        }*/
        //Debug.Log(justChanged); 
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "DogFeet" && !isDead) {
            getHit.Play();
            Die ();
		}
    }

    void Die() {
        isDead = true;
        anim.SetTrigger("Dead");
        tag = "Untagged";
        //GetComponent<Rigidbody2D>().gravityScale = 0f;
        //GetComponent<Collider2D>().isTrigger = true;
        Destroy(gameObject, 1.1f);
    }

    IEnumerator RandomMovement() {
        while (!isDead) {
            yield return new WaitForSeconds(1.0f);
            rb2D.velocity = new Vector2(speed * (Random.Range(-1.0f, 1.0f) > 0 ? 1.0f : -1.0f), 0);
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            rb2D.velocity = new Vector2(0, 0);
        }
    }

    void FixedUpdate() {
        if (!isDead) {
            if (move1Way) {
                if (moveLeft) {
                    rb2D.velocity = new Vector2(-speed, 0);
                }
                else {
                    rb2D.velocity = new Vector2(speed, 0);
                }
                if (Mathf.Abs(rb2D.velocity.x) < speed) {
                    if (rb2D.velocity.x < 0) {
                        rb2D.velocity = new Vector2(-speed, 0);
                    }
                    else {
                        rb2D.velocity = new Vector2(speed, 0);
                    }
                }
            }

            if (Mathf.Abs(rb2D.velocity.x) > 0.1f) {
                anim.SetBool("isMoving", true);
            }
            else {
                anim.SetBool("isMoving", false);
            }
        }
    }
}
