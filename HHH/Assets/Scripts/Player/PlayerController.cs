using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Vector2 lookVec; // public to get shoot direction

    private bool usingMouse = true;

    private Rigidbody2D rb;
    private Vector2 moveVec;

    // input
    private PlayerInp inp;
    private void Awake() {
        inp = new PlayerInp();
    }
    private void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        inp.Enable();
    }
    private void OnDisable() {
        inp.Disable();
    }

    private void Update() {
        // movement
        moveVec = inp.Ground.Move.ReadValue<Vector2>();
        
        // look
        if (Mouse.current.delta.EvaluateMagnitude() > 1) {
            usingMouse = true;
        }
        if (inp.Ground.Aim.ReadValue<Vector2>().magnitude > 0) {
            usingMouse = false;
        }

        if (usingMouse) {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            lookVec = new Vector2(worldPoint.x, worldPoint.y) - rb.position;
        }
        else {
            lookVec = inp.Ground.Aim.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate() {
        // movement
        rb.MovePosition(rb.position + moveVec * speed * Time.fixedDeltaTime);
        
        // look
        rb.rotation = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg - 90f;
    }
}
