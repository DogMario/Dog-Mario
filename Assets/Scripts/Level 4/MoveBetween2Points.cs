using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween2Points : MonoBehaviour {

    public float counter, travelDuration, resetDuration, waitDuration;
    public float startX;
    public float startY;
    public float endX;
    public float endY;
  
    private Vector3 posA;
    private Vector3 posB;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Start()
    {
        if (tag == "Spike")
        {
            endX = transform.position.x;
            endY = transform.position.y;
            startX = endX;
            startY = endY - 0.7f;
            travelDuration = 1.5f;
            resetDuration = 0.3f;
            waitDuration = 1f;
        }
        posA = new Vector3(startX, startY, 0f);
        posB = new Vector3(endX, endY, 0f);
        // Loops each cycles
        while (Application.isPlaying)
        {
            // First step, travel from A to B
            counter = 0f;
            while (counter < travelDuration)
            {
                transform.position = Vector3.Lerp(posA, posB, counter / travelDuration);
                counter += Time.deltaTime;
                yield return null;
            }

            // Make sure you're exactly at B, in case the counter 
            // wasn't precisely equal to travelDuration at the end
            transform.position = posB;

            // Second step, wait
            yield return new WaitForSeconds(waitDuration);

            // Third step, travel back from B to A
            counter = 0f;
            while (counter < resetDuration)
            {
                transform.position = Vector3.Lerp(posB, posA, counter / resetDuration);
                counter += Time.deltaTime;
                yield return null;
            }

            transform.position = posA;

            // Finally, wait
            yield return new WaitForSeconds(waitDuration);
        }
    }
}
