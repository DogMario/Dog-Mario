using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVerticalMovement : MonoBehaviour {

    public float speed = 2f;
    private Rigidbody2D rb2D;
    private FidgetBossMainScript mainScript;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
        rb2D = GetComponent<Rigidbody2D>();
        mainScript = GetComponent<FidgetBossMainScript>();
    }
	
    IEnumerator Move() {
        yield return new WaitForSeconds(3f);
        while(true) {
            yield return new WaitForSeconds(1.0f);
            if (!mainScript.toDiao) {
                rb2D.velocity = new Vector2(0, speed * (Random.Range(-1.0f, 1.0f) > 0 ? 1.0f : -1.0f));
                yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            }
            rb2D.velocity = new Vector2(0, 0);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 5), transform.position.z);
	}
}
