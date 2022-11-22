using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttributes : MonoBehaviour
{
    public float enemyHp = 4;
    public float maxEnemyHp = 4;

    private Slider enemyHpDisplaySlider;

    private void Start() {
        enemyHpDisplaySlider = transform.Find("Enemy HP Canvas").transform.Find("Enemy HP Slider").GetComponent<Slider>();
        enemyHpDisplaySlider.value = enemyHp/maxEnemyHp;
    }

    public void TakeEnemyDamage(float damageValue) {
        enemyHp -= damageValue;
        if(enemyHp <= 0) {
            Destroy(gameObject);
        }
        enemyHpDisplaySlider.value = enemyHp/maxEnemyHp;
    }
}
