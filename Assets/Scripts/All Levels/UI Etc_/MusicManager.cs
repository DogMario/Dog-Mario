using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource[] audioSources;
    private AudioSource BGM;
    private AudioSource deathClip;


	// Use this for initialization
	void Start () {
        audioSources = GetComponents<AudioSource>();
        BGM = audioSources[0];
        deathClip = audioSources[1];
        BGM.Play();
	}
	
	public void playDead () {
        BGM.Stop();
        deathClip.Play();
	}
}
