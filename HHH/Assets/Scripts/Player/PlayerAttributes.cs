using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public bool isHelpless = false;
    public float hitPoints;
    public float maxHitPoints;

    private Slider hpDisplaySlider;

    private void Start() {
        if(isHelpless) hpDisplaySlider = GameObject.Find("HP Display Helpless").GetComponent<Slider>();
        else hpDisplaySlider = GameObject.Find("HP Display").GetComponent<Slider>();
        hpDisplaySlider.value = hitPoints/maxHitPoints ;
    }

    public void TakeDamage(float damageValue) {
        hitPoints -= damageValue;
        if(hitPoints < 0) {
            hitPoints = 0;
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
        hpDisplaySlider.value = hitPoints/maxHitPoints;
    }
}