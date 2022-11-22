using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damageDone = 1;
    public float travelTime;
    
    private void Start() {
        Destroy(gameObject, travelTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collided = collision.gameObject;

        // bullet ignores these
        if(collided.tag.StartsWith("Bullet") || collided.CompareTag("Player")) {
            return;
        }

        // bullet destroys these
        if(collided.CompareTag("Tree") ) {
            Destroy(collided);
        }

        // damage Enemies
        if(collided.CompareTag("Enemy")) {
            collided.GetComponent<EnemyAttributes>().TakeEnemyDamage(damageDone);
        }

        Destroy(gameObject);
    }
}