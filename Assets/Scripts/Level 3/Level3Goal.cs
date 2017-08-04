using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Goal : MonoBehaviour {

    private Animator anim;
    public static bool passed;  //check if goal reached. access by calling Level3Goal.passed.
    private MusicManager musicManager;
    public GameObject firework;
    public GameObject confetti;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        passed = false;
        if (GameObject.FindGameObjectWithTag("MusicManager") != null) {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
    }
	
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            anim.SetTrigger("Passed");
            passed = true;
            musicManager.playClear();
            InvokeRepeating("Explode", 0.3f, 0.2f);
            Instantiate(confetti, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), new Quaternion(0, 0, 0, 0));
            other.transform.GetComponent<Level3PlayerController>().minY = other.transform.position.y - 0.5f;
            StartCoroutine(WaitAndQuit(other));
        }
    }

    void Explode() {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-6, 6), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-6,6));
        Instantiate(firework, position, Quaternion.Euler(-90,0,0));
    }

    IEnumerator WaitAndQuit(Collider other) {
        yield return new WaitForSeconds(4f);
        if (!other.transform.GetComponent<Level3PlayerController>().dead) {
            if (StaticLives.currLost < StaticLives.minLost) {
                GameObject.FindGameObjectWithTag("CanvasControl").GetComponent<Animator>().SetTrigger("UpdateMin");
                yield return new WaitForSeconds(0.2f);
                StaticLives.minLost = StaticLives.currLost;
                PlayerPrefs.SetInt("Cleared 3", 1);
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, StaticLives.minLost);
                yield return new WaitForSeconds(1.5f);
                StaticLives.currLost = 0;
            }
            else
                yield return new WaitForSeconds(1.7f);
            /*// quit for now
            #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                          Application.Quit();
            #endif*/
            SceneManager.LoadScene("Level 4");
        }
    }
}
