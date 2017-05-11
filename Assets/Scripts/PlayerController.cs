using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public Boundary boundary;
    //public float jumpHeight;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector2 velocity;
    float velocityXSmoothing;


    //private bool jumping;
    /*private AudioSource audiosource;
    private GameController gameController;
    
    void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gameController = new GameController();
        if (gameController == null) {
            Debug.Log("canot find gamecontroller script");
        }
    }
    */
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        // audiosource = GetComponent<AudioSource>(); 
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
    }

    /*void Update() {
        if((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
            if(gameController.getScore() >= 500) {
                Quaternion shot1Rotation = Quaternion.Euler(0.0f, shotSpawn[1].rotation.y, -rb.rotation.z);
                Quaternion shot2Rotation = Quaternion.Euler(0.0f, shotSpawn[2].rotation.y, -rb.rotation.z);
                Instantiate(shot, shotSpawn[1].position, shot1Rotation);
                Instantiate(shot, shotSpawn[2].position, shot2Rotation);
            }
            if(gameController.getScore() >= 2000) {
                fireRate = 0.0f;
                gameController.hazardSpawnWait = 0.2f;
                gameController.enemySpawnWait = 0.4f;
            }
            audiosource.Play();
        } 
    }*/

    void Update() {
        /*if (rb.velocity.y == 0f && !jumping && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {

        }*/
        if (Input.GetKeyDown(KeyCode.Space)) {
            velocity.y = maxJumpVelocity;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (velocity.y > minJumpVelocity) {
                velocity.y = minJumpVelocity;
            }
        }


        velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime, input);
    }

        void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, 0f);
        rb.velocity = new Vector2(moveHorizontal * speed, 0);
        
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),  
                                    Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax ));

        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
