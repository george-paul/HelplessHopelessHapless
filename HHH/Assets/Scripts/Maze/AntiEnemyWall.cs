using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiEnemyWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        // stop everything but these
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Buller_Player"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
