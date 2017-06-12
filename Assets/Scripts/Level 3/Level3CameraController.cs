using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3CameraController : MonoBehaviour {

    public GameObject target;
    public float damping = 1;
    Vector3 offset;
    private float posY;
    private float time;
    private float updateTime = 0.5f;
    private Vector3 additionalY;
    private Transform spawnPoint;
    private Rigidbody playerrb;

    void Start() {
        offset = target.transform.position - transform.position;
        posY = target.transform.position.y;
        time = Time.time;
        playerrb = target.GetComponent<FollowObjectPosition>().target.GetComponent<Rigidbody>();
    }

    void Update() {
        if(Time.time > time + updateTime) {
            additionalY = target.transform.position.y - posY < 0 ? new Vector3(0, target.transform.position.y - posY, 0) : Vector3.zero;
            //additionalY = target.transform.position.y - posY < 0 ? new Vector3(0, target.transform.position.y - posY, 0) : new Vector3(0,  target.transform.position.y - posY, 0);
            //additionalY = new Vector3(0, (target.transform.position.y - posY), 0);
            additionalY += new Vector3(0, playerrb.velocity.y > 0 || playerrb.velocity.y < -3? 0:playerrb.velocity.y * 3, 0);
            time = Time.time;
            posY = target.transform.position.y;
        }
    }

    void LateUpdate() {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = Vector3.Lerp(transform.position, target.transform.position - (rotation * offset) - additionalY, 2* Time.deltaTime);


        transform.LookAt(target.transform);
    }
}
