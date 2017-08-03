using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCameraPosition : MonoBehaviour {

    FallingCameraController fallingCamCon;
    public GameObject[] beams;
    public Vector3 newPos;
    public BeamShoot[] beamScripts;
    public SpriteRenderer[] beamSprs;
    public float timer = 1.5f;
    public float beamInterval = 1f;

    private int j = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fallingCamCon.camPos = newPos;
            if (beamSprs.Length > 0)
            {
                foreach (SpriteRenderer beamSpr in beamSprs)
                {
                    beamSpr.enabled = true;
                }
            }
            StartCoroutine(Wait(beamScripts, beamScripts.Length, timer, beamInterval));
  
        }
    }

    IEnumerator Wait(BeamShoot[] beamScripts, int numOfBeams, float timer, float beamInterval)
    {
       
        int beamNum = 0;
        float beamInt = beamInterval;

        while (beamNum < numOfBeams)
        {

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

            if (timer < 0)
            {
                while (beamInt > 0)
                {
                    beamInt -= Time.deltaTime;
                    yield return null;
                }
            }

            beamScripts[beamNum].setTrigger();
            beamInt = beamInterval;
            beamNum++;
        }
        

    }

    // Use this for initialization
    void Start () {
        fallingCamCon = GameObject.Find("Falling Camera").GetComponent<FallingCameraController>();

        for (int i = 0; i < beams.Length; i++)
        {
            beamScripts[i] = (BeamShoot)beams[i].GetComponent(typeof(BeamShoot));
            if (beamSprs.Length > 0)
            {
                beamSprs[i] = beams[i].GetComponent<SpriteRenderer>();
                beamSprs[i].enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
