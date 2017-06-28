using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirmanMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float counter = 0;
    private float limit = 0;
    Vector2 lastPosition;
    Rigidbody2D rb2d;

    private bool leftDone = false;
    private bool upDone = true;
    private bool rightDone = true;
    private float accumulatedDistance = 0;
    private float targetDistance;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (enabled)
        {

            while (!leftDone)
            {
                rb2d.velocity = new Vector2(-2.0f, 0);
            }
                if (!leftDone && accumulatedDistance > targetDistance)
            {
                leftDone = true;
                upDone = false;
            }
            
            
        }
    }
    /*
       // positions
       public Vector3[] positions = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
       //0 = Vector3(60.65, -12.35, 0);
       //1 = 

       private Vector3 startPos;
       private Vector3 endPos;

       // speeds
       private float speed = 2.0f;

       // variables controlling movement
       private float startTime;
       private float fracSpeed;

       // Use this for initialization
       void Update()
       {
           /*
          if (enabled)
           {
               startPos = positions[0];
               endPos = positions[1];
               float i = 0.0f;
               while (i < 1.0)
               {
                   i += Time.deltaTime * speed;
                   transform.position = Vector3.Lerp(startPos, endPos, speed * Time.deltaTime);
                   //MoveObject(startPos, endPos, 3f);
               }

          }



       private IEnumerator Start()
       {
           if (enabled)
           {
               startPos = positions[0];
               endPos = positions[1];
               float i = 0.0f;
               speed = 1.0f;
               while (i < 1.0)
               {
                   i += Time.deltaTime * speed;
                   transform.position = Vector3.Lerp(startPos, endPos, i);
                   yield return null;
               }
           }
       }

       IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float speed)
       {
           float i = 0.0f;
           while (i < 1.0)
           {
               i += Time.deltaTime * speed;
               transform.position = Vector3.Lerp(startPos, endPos, i);
               yield return null;
           }
       }

       */
}
