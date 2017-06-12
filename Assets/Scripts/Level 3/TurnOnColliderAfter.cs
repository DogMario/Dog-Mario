using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnColliderAfter : MonoBehaviour {

    public float waitTime;
    private Collider col;

	// Use this for initialization
	void Start () {
        col = GetComponent<Collider>();
        col.enabled = false;
        StartCoroutine(OnAfter(waitTime));
	}

    IEnumerator OnAfter(float f) {
        yield return new WaitForSeconds(f);
        col.enabled = true;
    }

}
