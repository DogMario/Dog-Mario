using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Clear : MonoBehaviour {

    private MusicManager musicManager;
    public string sceneName;
    public bool cleared;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("MusicManager") != null) {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
    }

    void Update() {
        if (cleared) {
            musicManager.playClear();
            StartCoroutine(WaitAndLoad());
            cleared = false;
        }
    }

    IEnumerator WaitAndLoad() {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }
}
