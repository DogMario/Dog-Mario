using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    //Application.Quit() only works outside of unity editor. i.e. need to build and run to see it work

    private Animator anim;
    private bool paused;
    private float pauseDelay = 0.5f;
    private float thisTime;
    private float originalTimeScale;

    void Start() {
        anim = GetComponent<Animator>();
        thisTime = Time.time;
        originalTimeScale = Time.timeScale;
        StartCoroutine(PauseRoutine());
    }

    IEnumerator PauseRoutine() {
        while (true) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (!paused) {
                    anim.SetBool("Paused", true);
                    paused = true;
                    thisTime = Time.time;
                    Time.timeScale = 0f;
                }
                else if (paused) {
                    anim.SetBool("Paused", false);
                    paused = false;
                    thisTime = Time.time;
                    Time.timeScale = originalTimeScale;
                }
            }
            yield return null;
        }
    }

	// Update is called once per frame
	/*void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            if (!paused && Time.time > thisTime + pauseDelay) {
                anim.SetBool("Paused", true);
                paused = true;
                thisTime = Time.time;
                Time.timeScale = 0f;
            }
            else if(paused && Time.time > thisTime + pauseDelay) {
                anim.SetBool("Paused", false);
                paused = false;
                thisTime = Time.time;
                Time.timeScale = originalTimeScale;
            }
        }
	}*/
}
