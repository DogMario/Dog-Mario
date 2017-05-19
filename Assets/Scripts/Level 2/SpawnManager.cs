using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject cabbage;

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

        yield return new WaitForSeconds(3f);

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
    }

	// Update is called once per frame
	void Update () {
		
	}
}
