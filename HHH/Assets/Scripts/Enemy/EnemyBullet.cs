using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float travelTime;
    public int damage = 1;
    
    private void Start() {
        Destroy(gameObject, travelTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collided = collision.gameObject;

        // bullet ignores these
        if(collided.tag.StartsWith("Bullet") || collided.CompareTag("Enemy")) {
            return;
        }

        // damage player
        if(collided.CompareTag("Player")) {
            collided.GetComponent<PlayerAttributes>().hitPoints -= damage;
        }

        Destroy(gameObject);
    }
}
