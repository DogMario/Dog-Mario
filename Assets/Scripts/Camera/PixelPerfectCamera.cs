using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{

    void Awake()
    {
        GetComponent<Camera>().orthographicSize = Screen.height / 2;
    }
}