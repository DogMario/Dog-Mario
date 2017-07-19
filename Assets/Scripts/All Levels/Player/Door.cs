using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public string sceneName;
    private MusicManager musicManager;

    void Start() {
        if (GameObject.FindGameObjectWithTag("MusicManager") != null) {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            StaticCheckpoint.checkpoint = 0;
            other.GetComponent<PlayerController>().canMove = false;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f, 0);
            /*Collider2D[] array = other.GetComponentsInChildren<Collider2D>();
            for(int i = 0; i < array.Length; i++) {
                array[i].enabled = false;
            }*/
            musicManager.playClear();
            StartCoroutine(WaitAndLoad(other.gameObject));    
        }
    }

    IEnumerator WaitAndLoad(GameObject other) {
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
}