using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnter2D : MonoBehaviour {

    public DisappearingBlocks script;

    private void Start()
    {
        if (script != null)
            script = this.transform.parent.GetComponent<DisappearingBlocks>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IgnoreCollision")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collide");
            if (script != null)
                script.enableTrigger();
        }


    }

  
}
