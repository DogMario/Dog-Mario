using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.SerializableAttribute]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class Level2PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 5;
    public Boundary boundary;
    public GameObject explosion;
    //private AudioSource audiosource;
    //private GameController gameController;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private MusicManager musicManager;
    private bool dead;
    private float randomYDrift;

    void Awake() {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        nextFire = 0.0f;
        //audiosource = GetComponent<AudioSource>(); 
    }

    void Update() {
        if(!dead && (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //audiosource.Play();
        } 
    }

    public void Die() {
        if (!dead) {
            Debug.Log("Player dead!"); //print Dead! in console -> for testing purposes
            dead = true;
            randomYDrift = Random.Range(-2f, 2f);
            StartCoroutine(PlayDeath());
            //play death animation here or call StartCoroutine(some IENumerator function that waits for animation.clip.length)
        }

    }

    IEnumerator PlayDeath() {
        //anim.setTrigger(dead) OR deathAnimation.Play() depending on using animator or animation
        Instantiate(explosion, transform);
        musicManager.playDead();
        transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f /*if using animation, change to deathAnimation.clip.Length*/);
        StaticLives.lives--;
        StaticLives.currLost++;
        SceneManager.LoadScene("Level 2"); //reload lv2
    }

    void FixedUpdate () {
        if (!dead) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * speed;

            rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                                        Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
        }
        else {
            rb.velocity = new Vector2(-3, randomYDrift);
            rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
        }
    }
}
