using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip audioClip;

	private bool audioPlayed = false;

	// Use this for initialization
	void Start () {
		//GetComponent<AudioSource> ().playOnAwake; //does not play on awake
	}

	void OnTriggerEnter2D(Collider2D other) { //Plays sound whenever collide
		if (audioPlayed == false && tag == "KillPlayer" && (other.tag == "Player" || other.tag == "DogHead" || other.tag == "DogFeet")) {
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = audioClip;
			audioSource.Play ();
			audioPlayed = true;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
