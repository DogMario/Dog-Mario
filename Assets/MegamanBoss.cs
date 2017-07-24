using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanBoss : MonoBehaviour {

    // body
    public int hp = 30;
    public bool isDead = false;

    // bullets
    public float bulletSpeed = 2f;
    public GameObject projectile;
    public GameObject megaman;
    private Vector3 firingPos;

    // devil transition
    public float transitionSpeed = 3f;

	// Use this for initialization
	void Start () {
        firingPos = transform.TransformPoint(megaman.transform.forward);
        //firingPos = new Vector3(110.06f, -77.71f, 0f);
        //firingPos = megaman.transform.forward;
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
        {

        }
	}

    IEnumerator Shoot()
    {
        Debug.Log(megaman.transform.forward.x + " " + megaman.transform.forward.y + " " + megaman.transform.forward.z);
        GameObject bullet = Instantiate(projectile, firingPos, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 3);
        yield return null;
    }

    void Die()
    {
        isDead = true;
        StartCoroutine(PlayDeath());
    }

    IEnumerator PlayDeath()
    {
        yield return null;
    }
}
