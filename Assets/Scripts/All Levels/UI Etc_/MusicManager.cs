using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource[] audioSources;
    private AudioSource BGM;
    private AudioSource deathClip;
    private AudioSource clearClip;
    private AudioSource airman;

	// Use this for initialization
	void Start () {
        audioSources = GetComponents<AudioSource>();
        BGM = audioSources[0];
        deathClip = audioSources[1];
        clearClip = audioSources[2];
        if(audioSources.Length > 3)
            airman = audioSources[3];
        BGM.Play();
	}

    public void stopAirmanPlayBGM()
    {
        airman.Stop();
        BGM.Play();
    }

    public void playAirman()
    {
        BGM.Stop();
        airman.Play();
    }
	
	public void playDead () {
        BGM.Stop();
        deathClip.Play();
	}

    public void playClear() {
        BGM.Stop();
        clearClip.Play();
    }


}
