using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlocks : MonoBehaviour {

    public bool triggered = false;
    public GameObject[] blocks;
    public int currentPoint;
    public float timeBetweenBlocks = 2f;
    public float timer = 0f;
    public bool move;
    public Renderer rndr;
    public Collider2D coll;
    private int currentBlock = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.tag == "Player")
        {
            triggered = true;
            // teleport 2nd block, fade 1st block
            // teleport 1st block, fade 2nd block
            // repeat
            //SetSequence();
        }
    }
    
    // Use this for initialization
    void Start () {
        rndr = GetComponent<Renderer>();
        Color color = rndr.material.color;
        Fade(color); //test
    }

	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            while (currentBlock < blocks.Length)
            {

            }
        }
	}

    void StartSequence()
    {

        //Fade(blocks[currentBlock]);

    }
    
    void Appear(Color color)
    {
        color.a = 1.0f;
        rndr.material.color = color;
    }

    void Fade(Color color)
    {
        
        color.a = 0.5f;
        rndr.material.color = color;
    }

    void Disappear(Color color, GameObject obj)
    {
        color.a = 0f;
        rndr.material.color = color;  
        coll.enabled = false;
    }

    public void enableTrigger()
    {
        Debug.Log("asd");
        triggered = true;
    }
}
