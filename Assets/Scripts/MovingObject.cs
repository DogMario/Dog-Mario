using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour { //abstract => class/class members can be incomplete and only implemented in derived class

	public float moveTime = 0.1f; //time for object to move in seconds
	public LayerMask blockingLayer; //layer on which to check collision

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime; //to make movement calculations more efficient

	// Use this for initialization
	protected virtual void Start () { //so Start() can be overridden by inheriting classes

		//component references
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime; //use multiplication -> more efficient 

	}

	//returns more than 1 value
	protected bool Move (int xDir, int yDir, out RaycastHit2D hit) {
		Vector2 start = transform.position; // current transform position = cast from Vector3 to Vector 2 to discard z axis
		Vector2 end = start + new Vector2 (xDir, yDir); //calc end position based on direction parameters

		boxCollider.enabled = false; //disable attached boxCollider2D so when we're casting our ray we're not hitting own colliders
		hit = Physics2D.Linecast (start, end, blockingLayer);
		boxCollider.enabled = true;

		if (hit.transform == null) {
			StartCoroutine (SmoothMovement (end));
			return true; // Move successful
		}

		return false;
	}

	// smooth movement co-routine for moving units from one space to the next
	// takes end to specify where to move to
	protected IEnumerator SmoothMovement (Vector3 end) {
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude; // calculate remaining distance to move based on 
		// sqr magnitude of the difference between current pos and end parameter

		while (sqrRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition(newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
	}

	//specify type of component we expect our unit to interact with if blocked

	protected virtual void AttemptMove <T> (int xDir, int yDir) 
		where T : Component {
		RaycastHit2D hit;
		bool canMove = Move (xDir, yDir, out hit);

		if (hit.transform == null)
			return;

		T hitComponent = hit.transform.GetComponent<T> ();

		if (!canMove && hitComponent != null)
			OnCantMove (hitComponent);
	}

	//is going to be overridden by functions in inheriting classes since abstract
	protected abstract void OnCantMove <T> (T component) 
		where T : Component; 
	

}