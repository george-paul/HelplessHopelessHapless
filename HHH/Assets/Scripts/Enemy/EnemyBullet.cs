using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float travelTime;
    public float damage = 1.0f;
    
    private void Start() {
        Destroy(gameObject, travelTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collided = collision.gameObject;

        // bullet ignores these
        if(collided.tag.StartsWith("Bullet") || collided.CompareTag("Enemy") || collided.gameObject.name == "Global Light Trigger"  || collided.gameObject.name == "Maze Trigger" || collided.gameObject.name == "Laser Puzzle Trigger" || collided.gameObject.name == "Boss Battle") {
            return;
        }

        // damage player
        if(collided.CompareTag("Player") || collided.CompareTag("Helpless")) {
            collided.GetComponent<PlayerAttributes>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
