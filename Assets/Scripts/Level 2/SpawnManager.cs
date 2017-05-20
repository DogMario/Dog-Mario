using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject cabbage;
    public GameObject shortSparkLink;
    public GameObject longSparkLink;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
	
    IEnumerator Spawn() {
        yield return new WaitForSeconds(2.0f);
        GameObject go;

        //Wave 1
        go = Instantiate(cabbage, new Vector2(9f, 4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 12110);
        go = Instantiate(cabbage, new Vector2(9f, 0f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 20110);
        go = Instantiate(cabbage, new Vector2(9f, -4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 12110);

        yield return new WaitForSeconds(1f);
        go = Instantiate(shortSparkLink, new Vector2(9f, 4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 900212);
        yield return new WaitForSeconds(1f);
        go = Instantiate(shortSparkLink, new Vector2(9f, -4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 450212);
        yield return new WaitForSeconds(1f);
        go = Instantiate(longSparkLink, new Vector2(9f, 1f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 000110);
        yield return new WaitForSeconds(1f);
        go = Instantiate(longSparkLink, new Vector2(9f, -1f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 200206);

        //Wave x
        go = Instantiate(cabbage, new Vector2(9f, 7f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, 5.5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, 4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, 2.5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, 1f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, 0f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, -1f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, -2.5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, -4f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, -5.5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);
        go = Instantiate(cabbage, new Vector2(9f, -7f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 110);

        yield return new WaitForSeconds(3f);
        go = Instantiate(cabbage, new Vector2(9f, 7f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f,0f,90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        yield return new WaitForSeconds(1f);
        go = Instantiate(cabbage, new Vector2(9f, 2f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        go = Instantiate(shortSparkLink, new Vector2(-6f, -9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        yield return new WaitForSeconds(1f);
        go = Instantiate(cabbage, new Vector2(9f, -2f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        go = Instantiate(shortSparkLink, new Vector2(-6f, -9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        yield return new WaitForSeconds(1f);
        go = Instantiate(cabbage, new Vector2(9f, -7f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        go = Instantiate(shortSparkLink, new Vector2(-6f, -9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        yield return new WaitForSeconds(1f);
        go = Instantiate(cabbage, new Vector2(9f, 2f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(cabbage, new Vector2(9f, -2f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        go = Instantiate(shortSparkLink, new Vector2(-6f, -9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        yield return new WaitForSeconds(1f);
        go = Instantiate(cabbage, new Vector2(9f, 5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(cabbage, new Vector2(9f, -5f), Quaternion.identity) as GameObject;
        go.SendMessage("CreateWith", 10110);
        go = Instantiate(shortSparkLink, new Vector2(6f, 9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);
        go = Instantiate(shortSparkLink, new Vector2(-6f, -9f), Quaternion.Euler(0f, 0f, 90f)) as GameObject;
        go.SendMessage("CreateWith", 000305);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
