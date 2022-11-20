using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadingLight : MonoBehaviour
{
    public float fadeTime = 1f;
    private float maxIntensity;
    private Light2D lightToFade;

    private void OnEnable() {
        lightToFade = GetComponent<Light2D>();
        maxIntensity = lightToFade.intensity;
    }

    private void FixedUpdate() {
        lightToFade.intensity -= maxIntensity * (Time.fixedDeltaTime / fadeTime);
        if(lightToFade.intensity <=0){
            Destroy(gameObject);
        }
            
    }
}
