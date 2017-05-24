using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetBossMainMovementScript : MonoBehaviour {

    public float speed = 0.05f;
    public GameObject fireShot;
    public Transform shotSpawn1;
    public float fireRate1;
    public GameObject blueShot;
    public Transform shotSpawn2;
    public float fireRate2;
    /*public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;*/

    //Animator anim;
    Quaternion smirk = Quaternion.Euler(0, 0, 0);
    Quaternion thankful = Quaternion.Euler(0, 0, 120);
    Quaternion diao = Quaternion.Euler(0, 0, -120);
    public bool toSmirk;
    public bool toThankful;
    public bool toDiao;
    private float nextFire1 = 3f;
    private float nextFire2 = 3f;
    private float nextFire3 = 3f;
    private float nextFire4 = 3f;

    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
        //Shooting
        if (Time.time > nextFire1) {
            nextFire1 = Time.time + fireRate1;
            Instantiate(fireShot, shotSpawn1.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
        if(toThankful && Time.time > nextFire2) {
            nextFire2 = Time.time + fireRate2;
            Instantiate(blueShot, shotSpawn2.position, shotSpawn2.rotation);
        }


        //Rotating
        if (toSmirk) {
            transform.rotation = Quaternion.Lerp(transform.rotation, smirk, Time.deltaTime * speed);
        }
        else if (toThankful) {
            transform.rotation = Quaternion.Lerp(transform.rotation, thankful, Time.deltaTime * speed);
        }
        else if (toDiao){
            transform.rotation = Quaternion.Lerp(transform.rotation, diao, Time.deltaTime * speed);
        }
    }

    IEnumerator Move() {
        while (true) {
            yield return new WaitForSeconds(5f);
            toThankful = true;
            yield return new WaitForSeconds(5f);
            toThankful = false;
            toDiao = true;
            yield return new WaitForSeconds(5f);
            toDiao = false;
            toSmirk = true;
            yield return new WaitForSeconds(5f);
            toSmirk = false;

        }
    }

    IEnumerator Wait(float f) {
        yield return new WaitForSeconds(f);
    }

    void FixedUpdate() {

    }
}
