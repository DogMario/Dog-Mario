using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
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
        rb = GetComponent<Rigidbody>();
       // audiosource = GetComponent<AudioSource>(); 
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

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),  
                                    Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax), 0);

        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
