using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShoot : MonoBehaviour {

    private bool triggered = false;
    private bool hitWall = false;

    public bool shootRight = true;
    private Vector3 direction = new Vector3(1, 0);
    public float timer = 5;
    public float beamSpeed = 7f;
    // Use this for initialization
    void Start () {
        
	}

    public void setTrigger()
    {
        triggered = true;
    }


    // Update is called once per frame
    void Update () {


        if (timer < 0)
        {
            hitWall = true;
        }

        if (triggered && !hitWall)
        {

            timer -= Time.deltaTime;
            {
                if (shootRight)
                {
                    transform.Translate(direction * beamSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(-1 * direction * beamSpeed * Time.deltaTime);
                }
            }
        }
	}
}
