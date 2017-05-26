using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovement : MonoBehaviour {

	// DIRECTIONS
	public bool left;
	public bool right;
	public bool up;
	public bool down;

	// VARIABLES TO STOP MOVEMENT AFTER SOME DISTANCE
	public float distanceToTravel;
	public bool movesThenStops;
	private bool isMoving = true;
	private float accumulatedDistance = 0;
	Vector2 lastPosition;

	// BASIC MOVEMENT VARIABLES
	public float speed;

	Rigidbody2D rb2D;
	Animator anim;
	AudioSource soundFx;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		accumulatedDistance += Vector2.Distance (transform.position, lastPosition);
		lastPosition = transform.position;

		if (movesThenStops) {
			if (accumulatedDistance >= distanceToTravel) {
				rb2D.velocity = new Vector2 (0, 0);
				speed = 0;
				isMoving = false;
			}
		}

		if (isMoving) {
			if (left) {
				rb2D.velocity = new Vector2 (-speed, 0);
				Debug.Log ("" + speed);
			}
			if (right) {
				rb2D.velocity = new Vector2 (speed, 0);
			}
			if (up) {
				rb2D.velocity = new Vector2 (0, speed);
			}
			if (down) {
				rb2D.velocity = new Vector2 (0, -speed);
			}
		}

	}
}
