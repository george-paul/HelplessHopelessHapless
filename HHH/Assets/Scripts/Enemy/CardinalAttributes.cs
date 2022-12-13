using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardinalAttributes : MonoBehaviour
{
    public float cardinalHp = 20;
    public float maxCardinalHp = 20;

    private Slider cardinalHpDisplaySlider;
    public AudioSource bossMusic;
    public AudioSource gameMusic;

    private void Start() {
        cardinalHpDisplaySlider = transform.Find("Cardinal HP Canvas").transform.Find("Cardinal HP Slider").GetComponent<Slider>();
        cardinalHpDisplaySlider.value = cardinalHp/maxCardinalHp;
    }

    public void TakeEnemyDamage(float damageValue) {
        cardinalHp -= damageValue;
        if(cardinalHp <= 0) {
            Destroy(gameObject);
            bossMusic.Stop();
            gameMusic.Play();
        }
        cardinalHpDisplaySlider.value = cardinalHp/maxCardinalHp;
    }
}
