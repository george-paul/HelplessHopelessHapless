using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject barrelEnd;
 
    public float muzzleVel = 20f;

    private Rigidbody2D rb;
    
    
    // input
    private PlayerInp inp;
    private void Awake() {
        inp = new PlayerInp();
    }
    private void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        inp.Enable();
        inp.Ground.Shoot.started += Shoot;
    }
    private void OnDisable() {
        inp.Disable();
    }

    void Shoot (InputAction.CallbackContext ctx) {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelEnd.transform.position, barrelEnd.transform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(barrelEnd.transform.up * muzzleVel, ForceMode2D.Impulse);
    }
}
