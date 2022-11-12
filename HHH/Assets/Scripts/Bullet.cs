using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float travelTime = 0.6f;
    
    private void Start() {
        Destroy(gameObject, travelTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collided = collision.gameObject;
        if(collided.tag == "Tree")
        {
            Destroy(collided);
        }
        if (collided.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
