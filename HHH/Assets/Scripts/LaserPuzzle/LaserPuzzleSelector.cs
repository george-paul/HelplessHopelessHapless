using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserPuzzleSelector : MonoBehaviour
{
    public bool isPuzzling = false;

    public List<GameObject> puzzleElementsRow1;
    public List<GameObject> puzzleElementsRow2;

    private SpriteRenderer selectorSprite;
    private List<List<GameObject>> puzzleElements = new List<List<GameObject>>() {};

    (int, int) currentlySelected = (0,0);

    public void SetPuzzling(bool whetherPuzzling) {
        isPuzzling = whetherPuzzling;
        selectorSprite.enabled = whetherPuzzling;
    }

    // input
    private PlayerInp inp;
    private void Awake() {
        inp = new PlayerInp();
    }
    private void OnEnable() {
        selectorSprite = transform.Find("Selector Sprite").GetComponent<SpriteRenderer>();
        inp.Enable();
    }
    private void OnDisable() {
        inp.Disable();
    }

    private void Start() {
        puzzleElements.Add(puzzleElementsRow1);
        puzzleElements.Add(puzzleElementsRow2);

        inp.Ground.Aim.started += (ctx) => MoveSelector(ctx);
        inp.Ground.Shoot.performed += (ctx) => RotateSelected();
    }

    void MoveSelector(InputAction.CallbackContext ctx) {
        if(!isPuzzling) return; // do nothing if not puzzling

        Vector2 vec = ctx.ReadValue<Vector2>();

        float angle = Vector2.SignedAngle(Vector2.right, vec);
        if (angle < 0) {
            angle = (-angle) + 180; 
        }

        // right
        if(angle <= 45 || angle > 315) {
            if(currentlySelected.Item2 < puzzleElementsRow1.Count-1) currentlySelected.Item2 += 1;
            else currentlySelected.Item2 = 0;
        }
        // up
        else if(angle <= 135 && angle > 45) {
            if(currentlySelected.Item1 == 0) currentlySelected.Item1 = 1;
            else currentlySelected.Item1 = 0;
        }
        // left
        else if(angle <= 225 && angle > 135) {
            if(currentlySelected.Item2 > 0) currentlySelected.Item2 -= 1;
            else currentlySelected.Item2 = puzzleElementsRow1.Count-1;
        }
        // down
        // ie: if (angle <= 315 && angle > 225)
        else {
            if(currentlySelected.Item1 == 1) currentlySelected.Item1 = 0;
            else currentlySelected.Item1 = 1;
        }

        transform.position = puzzleElements[currentlySelected.Item1][currentlySelected.Item2].transform.position;
    }

    void RotateSelected() {
        Transform t =puzzleElements[currentlySelected.Item1][currentlySelected.Item2].transform;
        t.Rotate(0,0,90);
    }
}
