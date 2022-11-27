using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLaserPuzzle : MonoBehaviour
{
    public GameObject helpless;
    public float puzzleCameraSize = 9;

    private float savedCameraSize;
    private CameraFollow followScript;
    private GameObject laserPuzzleCenter;
    private GameObject helplessLocation;
    private GameObject puzzleSelector;

    private GameObject instantiatedHelpless;
    
    private void OnEnable() {
        followScript = Camera.main.GetComponent<CameraFollow>();
        savedCameraSize = Camera.main.orthographicSize;
        laserPuzzleCenter = GameObject.Find("/Laser Puzzle/Laser Puzzle Trigger");
        helplessLocation = GameObject.Find("/Laser Puzzle/Helpless Location");
        puzzleSelector = GameObject.Find("/Laser Puzzle/Laser Puzzle Selector");
    }

    private void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.name.CompareTo("Laser Puzzle Trigger") == 0) {
            // start puzzle
            followScript.toFollow = laserPuzzleCenter;
            Camera.main.orthographicSize = puzzleCameraSize;
            instantiatedHelpless = Instantiate(helpless, helplessLocation.transform.position, helplessLocation.transform.rotation);
            puzzleSelector.GetComponent<LaserPuzzleSelector>().SetPuzzling(true);
        }
    }

    private void OnTriggerExit2D(Collider2D trigger) {
        if (trigger.name.CompareTo("Laser Puzzle Trigger") == 0) {
            // end puzzle
            followScript.toFollow = gameObject;
            Camera.main.orthographicSize = savedCameraSize;
            Destroy(instantiatedHelpless);
            puzzleSelector.GetComponent<LaserPuzzleSelector>().SetPuzzling(false);
        }
    }
}
