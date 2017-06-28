using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLerp : MonoBehaviour {
    public Transform[] positions;
    public int i = 0;
    public float lerpAmount = 0;
    public float lerpSpeed = 0.01f;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
   

    void Update()
    {

        //The lerpfloat should always be reset back to 0 otherwise you'd start teleporting.
        if (lerpAmount >= 1f)
            lerpAmount = 0;
        lerpAmount += lerpSpeed * Time.deltaTime;
        //Here the lerp from place to place takes place, I used %3 because I've 3 elements in my array, this way it keeps looping between these positions.
        transform.position = Vector3.Lerp(positions[i % 3].position, positions[(i + 1) % 3].position, lerpAmount);
        //The code explains it self I guess.
        transform.LookAt(positions[(i + 1) % 3]);
        //since lerp never actually reaches its target you need to check for the distance and can't just say if the lerps final position is reached up "i" by 1.
        if (Vector3.Distance(transform.position, positions[(i + 1) % 3].position) < 0.13333)
        {
            i++;
            lerpAmount = 1;
        }
    }
}
