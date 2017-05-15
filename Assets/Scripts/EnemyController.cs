using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public KillPlayer killPlayer; //KillPlayer script
    public bool move1Way;
    public bool moveLeft = true;
    public float speed;
    //public AudioClip deathClip;
    Rigidbody2D rb2D;
    Animator anim;
    bool isDead;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        if (!move1Way) {
            StartCoroutine(RandomMovement());
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "DogFeet") {
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
            //rb2D.velocity = new Vector2(-speed, 0);
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
                if (rb2D.velocity.x == 0) {
                    moveLeft = !moveLeft;
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
