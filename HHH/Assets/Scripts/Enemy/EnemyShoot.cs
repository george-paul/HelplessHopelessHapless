using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float muzzleVel;
    public bool isShooting = true;
    public float shootDelay;
    public GameObject enemyBulletPrefab;
    public Transform enemyBarrelEnd;

    private void OnEnable() {
        enemyBarrelEnd = gameObject.transform.Find("Enemy Barrel End");
    }

    private void Start() {
        StartCoroutine(FireEnemyBullet());
    }

    IEnumerator FireEnemyBullet() {
        while(isShooting)
        {
            yield return new WaitForSeconds(shootDelay);
            // fire bullet
            GameObject bullet = Instantiate(enemyBulletPrefab, enemyBarrelEnd.position, enemyBarrelEnd.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(enemyBarrelEnd.up * muzzleVel, ForceMode2D.Impulse);
        }
        yield break;
    }
}
