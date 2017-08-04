﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pause : MonoBehaviour {

    //Application.Quit() only works outside of unity editor. i.e. need to build and run to see it work

    public AudioMixerSnapshot pausedSS;
    public AudioMixerSnapshot unpausedSS;
    public AudioMixer master;

    private Animator anim;
    private bool paused;
    private float originalTimeScale;
    private int index = 0;

    void Start() {
        anim = GetComponent<Animator>();
        //thisTime = Time.time;
        originalTimeScale = Time.timeScale;
        StartCoroutine(PauseRoutine());
    }

    IEnumerator PauseRoutine() {
        while (true) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (!paused) {
                    anim.SetBool("Paused", true);
                    paused = true;
                    float value;
                    master.GetFloat("MusicVol", out value);
                    master.SetFloat("MusicVol", value - 3.0f);
                    master.SetFloat("SFXVol", 0);
                    Time.timeScale = 0f;
                }
                else if (paused) {
                    anim.SetBool("Paused", false);
                    paused = false;
                    yield return new WaitForSecondsRealtime(0.75f);
                    float value;
                    master.GetFloat("MusicVol", out value);
                    master.SetFloat("MusicVol", value == 0f? 0f : value + 3.0f);
                    index = 0;
                    Time.timeScale = originalTimeScale;
                }
            }
            if (paused) {
                if (index == 0) {
                    anim.SetInteger("Index", 0);
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                        index = 1;
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                        index = 2;
                    if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && StaticVolume.staticMusicVol > 0) {
                        StaticVolume.staticMusicVol--;
                        master.SetFloat("MusicVol", (StaticVolume.staticMusicVol - 5) * 2);
                    }
                    if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && StaticVolume.staticMusicVol < 10) {
                        StaticVolume.staticMusicVol++;
                        master.SetFloat("MusicVol", (StaticVolume.staticMusicVol - 5) * 2);
                    }
                }
                else if (index == 1) {
                    anim.SetInteger("Index", 1);
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                        index = 2;
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                        index = 0;
                    if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && StaticVolume.staticSFXVol > 0) {
                        StaticVolume.staticSFXVol--;
                        if(StaticVolume.staticSFXVol == 0)
                            master.SetFloat("SFXVol", 0);
                        else
                            master.SetFloat("SFXVol", (StaticVolume.staticSFXVol - 5) * 2);
                    }
                    if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && StaticVolume.staticSFXVol < 10) {
                        StaticVolume.staticSFXVol++;
                        master.SetFloat("SFXVol", (StaticVolume.staticSFXVol - 5) * 2);
                    }
                }
                else if(index == 2) {
                    anim.SetInteger("Index", 2);
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                        index = 0;
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                        index = 1;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                        #if UNITY_EDITOR
                        // Application.Quit() does not work in the editor so
                        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                        UnityEditor.EditorApplication.isPlaying = false;
                        #else
                          Application.Quit();
                        #endif
                    }
                }
            }
            yield return null;
        }
    }
}
