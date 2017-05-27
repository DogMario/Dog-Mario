using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetBossMainScript : MonoBehaviour {


    public int hp = 40;
    public int threshold = 15;
    public float speed = 2f;
    public GameObject fireShot;
    public Transform shotSpawn1;
    public float fireRate1;
    public GameObject blueShot;
    public Transform shotSpawn2;
    public float fireRate2;
    public GameObject greenLaser;
    public Transform shotSpawn3;
    public float fireRate3 = 8f;
    public float laserDelay = 1.5f; //laser delay
    public GameObject poisonCloud;
    public Transform shotSpawn4;
    public float fireRate4;
    public GameObject player;
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
    //private Rigidbody2D rb2D;
    public float diaoStart;
    

    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        //rb2D = GetComponent<Rigidbody2D>();
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
        if(toDiao && Time.time > diaoStart + laserDelay && Time.time > nextFire3) {
            nextFire3 = Time.time + fireRate3;
            Instantiate(greenLaser, shotSpawn3.position, shotSpawn3.rotation);
        }
        if (toSmirk && Time.time > nextFire4) {
            nextFire4 = Time.time + fireRate4;
            Instantiate(poisonCloud, shotSpawn4.position, shotSpawn4.rotation);
        }

        if(hp == threshold) {
            fireRate1 = 0.12f;
            fireRate2 = 0.08f;
            fireRate4 = 0.4f;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1f,0.52f,0.4f);
        }

        if (hp <= 0) {
            Die();
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

    public void Die() {
        Destroy(gameObject);
    }

    IEnumerator Move() {
        yield return new WaitForSeconds(3f);
        while (hp > threshold) {
            toThankful = true;
            yield return new WaitForSeconds(5f);
            toThankful = false;
            toDiao = true;
            diaoStart = Time.time;
            yield return new WaitForSeconds(5f);
            toDiao = false;
            toSmirk = true;
            yield return new WaitForSeconds(5f);
            toSmirk = false;
        }
        while(hp > 0) {
            toThankful = true;
            yield return new WaitForSeconds(3f);
            toThankful = false;
            toDiao = true;
            diaoStart = Time.time;
            yield return new WaitForSeconds(5f);
            toDiao = false;
            toSmirk = true;
            yield return new WaitForSeconds(3f);
            toSmirk = false;
        }
    }

    IEnumerator Wait(float f) {
        yield return new WaitForSeconds(f);
    }

    void FixedUpdate() {
        if(transform.position.x > 5.75) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(5.75f, transform.position.y, transform.position.z), Time.deltaTime * 1f);
        }
    }
}
