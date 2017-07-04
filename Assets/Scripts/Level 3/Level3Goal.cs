using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Goal : MonoBehaviour {

    private Animator anim;
    public static bool passed;  //check if goal reached. access by calling Level3Goal.passed.
    private MusicManager musicManager;
    public GameObject firework;
    public GameObject confetti;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        passed = false;
        if (GameObject.FindGameObjectWithTag("MusicManager") != null) {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
    }
	
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            anim.SetTrigger("Passed");
            passed = true;
            musicManager.playClear();
            InvokeRepeating("Explode", 0.3f, 0.2f);
            Instantiate(confetti, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), new Quaternion(0, 0, 0, 0));
            StartCoroutine(WaitAndQuit());
        }
    }

    void Explode() {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-6, 6), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-6,6));
        Instantiate(firework, position, Quaternion.Euler(-90,0,0));
    }

    IEnumerator WaitAndQuit() {
        yield return new WaitForSeconds(3f);

        Application.Quit();
    }
}
