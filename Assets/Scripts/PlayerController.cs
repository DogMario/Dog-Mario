using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 20;

	// FOR: Dialogue boxes when chars are talking
	// SCRIPT: TextBoxManager
	// control player movement during dialogue
	public bool canMove;

    /*private SpriteRenderer spriteRenderer;
    private GameObject feet;
    private GameObject head;*/
    private MusicManager musicManager;
    private bool dead;
    private Animator animator;
    private bool reachedFlag;
    private AudioSource bork;

    // Use this for initialization
    void Awake() {
        /*spriteRenderer = GetComponent<SpriteRenderer>();
        feet = GameObject.Find("Feet Collider");
        head = GameObject.Find("Head Collider");*/
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        animator = GetComponent<Animator>();
        bork = GetComponent<AudioSource>();
    }
		

    protected override void ComputeVelocity() {
		if (!canMove) {
			return;
		}

        if (!dead) {
            if (!reachedFlag) {
                Vector2 move = Vector2.zero;

                move.x = Input.GetAxis("Horizontal");

                if (Input.GetButtonDown("Jump") && grounded) {
                    velocity.y = jumpTakeOffSpeed;
                    bork.Play();
                }
                else if (Input.GetButtonUp("Jump")) {
                    if (velocity.y > 0) {
                        velocity.y = velocity.y * 0.5f;
                    }
                }

                bool flipSprite = (Mathf.Abs(Mathf.Round(transform.rotation.y)) == 1 ? (move.x > 0.1f) : (move.x < -0.1f));
                if (flipSprite) {
                    transform.rotation = Quaternion.Euler(0f, (Mathf.Abs(Mathf.Round(transform.rotation.y)) == 1 ? 0f : 180f), 0);
                }

                //if dw play move animation, add (grounded) into condition
                if (Mathf.Abs(velocity.x) > 0.01f) {
                    animator.SetBool("isMoving", true);
                }
                else {
                    animator.SetBool("isMoving", false);
                }

                targetVelocity = move * maxSpeed;

                if (transform.position.y < -5.0f) {  //drop to death
                    Die();
                }
            }
            else {
                if (!grounded) {
                    velocity.x = 0;
                    velocity.y = -2;
                }
                else {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    if (transform.rotation.y == 1) {
                        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    }
                    velocity.y = 0;
                    targetVelocity = new Vector2(2f,0f);
                }
                if (transform.position.y < -5.0f) {  //drop to death
                    Die();
                }
            }
        }
    }

    public void Die() {
        if (!dead) {
            Debug.Log("Player dead!"); //print Dead! in console -> for testing purposes
            dead = true;
            rb2d.velocity.Set(0f, 0f);
            StartCoroutine(PlayDeath());
        }
        
    }

    IEnumerator PlayDeath() {
        animator.SetTrigger("dead");
        musicManager.playDead();
        yield return new WaitForSeconds(1.5f /*if using animation, change to deathAnimation.clip.Length*/);
        StaticLives.lives--;
        SceneManager.LoadScene("Level 1"); //load level 1 for now
    }

    public bool isGrounded() {
        return grounded;
    }

    public void ReachFlag() {
        reachedFlag = true;
    }

    public Vector3 getSpeed() {
        return velocity;
    }
}