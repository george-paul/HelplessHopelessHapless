using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleTrigger : MonoBehaviour
{
    public GameObject cardinalEnemy;
    public AudioSource bossMusic;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Instantiate(cardinalEnemy, transform.position, transform.rotation);
            bossMusic.Play();
        }
    }
}
