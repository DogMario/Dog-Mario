using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int movementPattern = 1;
    public float speed;

    private Rigidbody2D rb;
    Vector2 startPos;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Use this for initialization
    void Start () {
        //Move(movementPattern);
	}


    void Move(int movementPattern) {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate() {
        switch (movementPattern) {
            case 1:
                if (rb.transform.position.x > 4f) {
                    rb.velocity = speed * Vector2.left;
                }
                else if(rb.transform.position.x > -3f) {
                    rb.velocity = speed * new Vector2(-0.75f, (-startPos.y / 5.25f));
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
