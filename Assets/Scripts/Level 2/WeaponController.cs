using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    private EnemyMovement enemyMovement;
    //private AudioSource audiosource;

    void Start() {
        //audiosource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Fire() {
        if (!enemyMovement.isDead) {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //audiosource.Play();
        }
    }
}
