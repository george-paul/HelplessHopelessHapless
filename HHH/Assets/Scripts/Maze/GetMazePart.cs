using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMazePart : MonoBehaviour
{
    private PartsTracker tracker;

    private void Start() {
        tracker = GameObject.Find("/Canvas/Parts Display").GetComponent<PartsTracker>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            tracker.AddPart();
        }
        Destroy(gameObject, 0.2f);
    }
}
