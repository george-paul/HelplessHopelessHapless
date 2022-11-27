using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttributes : MonoBehaviour
{
    public bool isCardinal = false;

    public float enemyHp = 4;
    public float maxEnemyHp = 4;

    private Slider enemyHpDisplaySlider;

    private void Start() {
        if(isCardinal) enemyHpDisplaySlider = transform.Find("Cardinal HP Canvas").transform.Find("Cardinal HP Slider").GetComponent<Slider>();
        else enemyHpDisplaySlider = transform.Find("Enemy HP Canvas").transform.Find("Enemy HP Slider").GetComponent<Slider>();
        enemyHpDisplaySlider.value = enemyHp/maxEnemyHp;
    }

    public void TakeEnemyDamage(float damageValue) {
        enemyHp -= damageValue;
        if(enemyHp <= 0) {
            if(isCardinal)
            {
                GameObject.Find("/Canvas/Parts Display").GetComponent<PartsTracker>().AddPart();
            }
            Destroy(gameObject);
        }
        enemyHpDisplaySlider.value = enemyHp/maxEnemyHp;
    }
}
