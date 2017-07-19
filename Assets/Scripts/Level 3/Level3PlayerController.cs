using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3PlayerController : MonoBehaviour {
    public float movementSpeed = 10;
    public float turningSpeed = 60;
    public Transform spawnPoint;
    public float minY = -50;

    public bool dead;
    private Rigidbody rb;
    private float lastY;
    private MusicManager musicManager;

    void Start() {
        rb = GetComponent<Rigidbody>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        if (spawnPoint != null) {
            transform.position = spawnPoint.position;
        }
    }

    void Update() {
        if (!dead && !Level3Goal.passed) {
            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            rb.AddForce(Camera.main.transform.forward * vertical);
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed * 0.5f * Time.deltaTime;
            rb.AddForce(Camera.main.transform.right * horizontal);

        }
        if (!dead) {
            if (transform.position.y < minY) {
                dead = true;
                StartCoroutine(PlayDeath());
            }
        }
    }

    public IEnumerator PlayDeath() {
        musicManager.playDead();
        yield return new WaitForSeconds(2.2f);
        StaticLives.lives--;
        StaticLives.currLost++;
        SceneManager.LoadScene("Level 3"); //reload lv3
    }

    public bool isDead() {
        return dead;
    }
}