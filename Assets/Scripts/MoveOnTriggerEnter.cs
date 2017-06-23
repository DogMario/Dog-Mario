using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTriggerEnter : MonoBehaviour
{
    private bool triggered = false;

    // variables controlling movement
    public int numWayPoints;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed;
    public float xPos;
    public float yPos;


    private float startTime;
    private Vector3[] waypoints;
    private float[] speeds;
    private float fracSpeed;
    private int targetWayPoint;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;

        // initialise way points for object to move through
        waypoints = new Vector3[numWayPoints];
        waypoints[0] = transform.position;
        for (targetWayPoint = 1; targetWayPoint < numWayPoints; targetWayPoint++)
        {
                xPos = 0f;
                yPos = 0f;
                waypoints[targetWayPoint] = new Vector3(xPos, yPos, 0); 
        }

        targetWayPoint = 0;

        if (waypoints.Length == 0)
        {
            Debug.Log("No waypoints found");
        }
        targetWayPoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speeds[targetWayPoint];
        fracSpeed = (Time.time - startTime) * speed;
        transform.position = Vector3.Lerp(startPoint, endPoint, fracSpeed);

        if (fracSpeed >= 1)
        {
            startTime = Time.time;
            targetWayPoint++;
            startPoint = endPoint;
            endPoint = waypoints[targetWayPoint];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !triggered)
        {
            triggered = true;
        }
    }
}
