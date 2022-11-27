using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalShoot : MonoBehaviour
{
    public float muzzleVel;
    public bool isShooting = true;
    public float shootDelay;
    public float cardinalDelay;
    public GameObject enemyBulletPrefab;
    public Transform cardinalBarrelEndUp;
    public Transform cardinalBarrelEndDown;
    public Transform cardinalBarrelEndLeft;
    public Transform cardinalBarrelEndRight;

    private void OnEnable() {
        cardinalBarrelEndUp = gameObject.transform.Find("Cardinal Barrel End Up");
        cardinalBarrelEndDown = gameObject.transform.Find("Cardinal Barrel End Down");
        cardinalBarrelEndLeft = gameObject.transform.Find("Cardinal Barrel End Left");
        cardinalBarrelEndRight = gameObject.transform.Find("Cardinal Barrel End Right");
    }

    private void Start() {
        StartCoroutine(FireCardinalBullet());
    }

    IEnumerator FireCardinalBullet() {
        while(isShooting)
        {
            yield return new WaitForSeconds(shootDelay);
            // fire bullet
            GameObject bullet1 = Instantiate(enemyBulletPrefab, cardinalBarrelEndUp.position, cardinalBarrelEndUp.rotation);
            Rigidbody2D bulletRb = bullet1.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(cardinalBarrelEndUp.up * muzzleVel, ForceMode2D.Impulse);

            yield return new WaitForSeconds(cardinalDelay);

            GameObject bullet2 = Instantiate(enemyBulletPrefab, cardinalBarrelEndDown.position, cardinalBarrelEndDown.rotation);
            Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();
            bulletRb2.AddForce(cardinalBarrelEndDown.up * muzzleVel, ForceMode2D.Impulse);
        
            yield return new WaitForSeconds(cardinalDelay);

            GameObject bullet3 = Instantiate(enemyBulletPrefab, cardinalBarrelEndLeft.position, cardinalBarrelEndLeft.rotation);
            Rigidbody2D bulletRb3 = bullet3.GetComponent<Rigidbody2D>();
            bulletRb3.AddForce(cardinalBarrelEndLeft.up * muzzleVel, ForceMode2D.Impulse);

            yield return new WaitForSeconds(cardinalDelay);

            GameObject bullet4 = Instantiate(enemyBulletPrefab, cardinalBarrelEndRight.position, cardinalBarrelEndRight.rotation);
            Rigidbody2D bulletRb4 = bullet4.GetComponent<Rigidbody2D>();
            bulletRb4.AddForce(cardinalBarrelEndRight.up * muzzleVel, ForceMode2D.Impulse);
        }
        yield break;
    }
}
