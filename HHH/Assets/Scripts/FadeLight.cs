using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeLight : MonoBehaviour
{
    public float fadeTime = 1f;

    private void OnDisable() {
        GameObject fadingLight = Instantiate(gameObject, transform.position, transform.rotation);
        Destroy(fadingLight.GetComponent<FadeLight>());
        Light2D lightComponent = fadingLight.GetComponent<Light2D>();
        lightComponent.enabled = true;
        FadingLight fadingLightComponent = fadingLight.AddComponent<FadingLight>();
        fadingLightComponent.fadeTime = fadeTime;
    }
}