using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaplessTrigger : MonoBehaviour
{
    private Dialogue dialogue;

    private void OnEnable() {
        dialogue = GameObject.Find("Player").GetComponent<Dialogue>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

    }
}
