using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{

    public ChangeCamera mainCam;
    //public ChangeCamera fallingCam;
    private bool triggered = false;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<ChangeCamera>();
        //fallingCam = GameObject.Find("Falling Camera").GetComponent<ChangeCamera>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !triggered)
        {
            triggered = true;
            mainCam.camChange = true;
            //fallingCam.camChange = true;
        }
    }

}
