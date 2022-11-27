using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLaserPuzzle : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger) {
        if (trigger.name.CompareTo("Laser Puzzle Trigger") == 0) {
            Camera.main.GetComponent<CameraFollow>();
        }
    }
}
