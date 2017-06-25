using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Goal : MonoBehaviour {

    private Animator anim;
    public static bool passed;  //check if goal reached. access by calling Level3Goal.passed.
    private MusicManager musicManager;

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
            StartCoroutine(WaitAndQuit());
        }
    }

    IEnumerator WaitAndQuit() {
        yield return new WaitForSeconds(3f);

        Application.Quit();
    }
}
