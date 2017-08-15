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

        if (SceneManager.GetActiveScene().name.Equals("Level 1")) {
            PlayerPrefs.SetInt("Cleared 1", 1);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 4")) {
            PlayerPrefs.SetInt("Cleared 4", 1);
        }

        yield return new WaitForSeconds(3.5f);

        StaticLives.currLost = 0;

        if (SceneManager.GetActiveScene().name.Equals("Level 1")) {
            if (PlayerPrefs.GetInt("Cleared 2") != 1)
                SceneManager.LoadScene("Level 2");
            else if (PlayerPrefs.GetInt("Cleared 3") != 1)
                SceneManager.LoadScene("Level 3");
            else if (PlayerPrefs.GetInt("Cleared 4") != 1)
                SceneManager.LoadScene("Level 4");
            else
                SceneManager.LoadScene("Credits");
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 4")) {
            if (PlayerPrefs.GetInt("Cleared 1") != 1)
                SceneManager.LoadScene("Level 1");
            else if (PlayerPrefs.GetInt("Cleared 2") != 1)
                SceneManager.LoadScene("Level 2");
            else if (PlayerPrefs.GetInt("Cleared 3") != 1)
                SceneManager.LoadScene("Level 3");
            else
                SceneManager.LoadScene("Credits");
        }
    }
}