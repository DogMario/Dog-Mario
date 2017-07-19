using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Clear : MonoBehaviour {

    private MusicManager musicManager;
    public string sceneName;
    public bool cleared;
    public GameObject firework;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("MusicManager") != null) {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
    }

    void Update() {
        if (cleared) {
            musicManager.playClear();
            InvokeRepeating("Explode", 0.5f, 0.3f);
            StartCoroutine(WaitAndLoad());
            cleared = false;
        }
    }

    IEnumerator WaitAndLoad() {
        yield return new WaitForSeconds(0.5f);
        if (StaticLives.currLost < StaticLives.minLost) {
            GameObject.FindGameObjectWithTag("CanvasControl").GetComponent<Animator>().SetTrigger("UpdateMin");
            yield return new WaitForSeconds(0.2f);
            StaticLives.minLost = StaticLives.currLost;
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, StaticLives.minLost);
        }
        yield return new WaitForSeconds(3.5f);
        StaticLives.currLost = 0;
        SceneManager.LoadScene(sceneName);
    }

    void Explode() {
        Vector3 position = new Vector3(Random.Range(-6, 6),Random.Range(-5, 5), -1);
        Instantiate(firework, position, new Quaternion(0, 0, 0, 0));
    }
}
