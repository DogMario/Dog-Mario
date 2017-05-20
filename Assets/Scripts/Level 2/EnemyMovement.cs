using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int movementPattern = 1;
    public float speed;
    public int convergePoint = 1;
    public int convergeDist = 4;
    private Rigidbody2D rb;
    Vector2 startPos;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    public void CreateWith(int value) { //Converge point, converge dist, movement pattern, speed, speed
        this.speed = (float)(value % 100);
        movementPattern = (value / 100) % 10;
        if (value / 1000 != 0) {
            convergeDist = (value / 1000) % 10;
            convergePoint = value / 10000;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "DogFeet") {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

    void FixedUpdate() {
        switch (movementPattern) {
            case 1: //_,-
                if (rb.transform.position.x > convergePoint + convergeDist) {
                    rb.velocity = speed * Vector2.left;
                }
                else if(rb.transform.position.x > convergePoint - convergeDist) {
                    rb.velocity = speed * new Vector2(-0.75f, (-startPos.y / (2*convergeDist)));
                }
                else {
                    rb.velocity = speed * Vector2.left;
                }
                break;
            case 2: //move up/down only
                rb.velocity = speed * Vector2.down * Mathf.Sign(startPos.y);
                break;

        }
    }
}
