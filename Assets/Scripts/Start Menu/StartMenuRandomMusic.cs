using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuRandomMusic : MonoBehaviour {

    private AudioSource[] music;

	// Use this for initialization
	void Start () {
        music = GetComponents<AudioSource>();
        music[Random.Range(0, music.Length)].Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
