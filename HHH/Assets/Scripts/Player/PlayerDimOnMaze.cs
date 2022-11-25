using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDimOnMaze : MonoBehaviour
{
    public float playerLightIncrease = 0.9f;
    public float playerRadiusIncrease = 1.3f;
    public float fadeTime = 1f;
    
    private Light2D globalLight;
    private float globalUpper;
    private float globalLower;

    private Light2D playerLight;
    private float playerUpper;
    private float playerLower;
    
    private float radiusUpper;
    private float radiusLower;

    private EnemyManager enemyManager;

    private void OnEnable() {
        globalLight = GameObject.Find("Global Light").GetComponent<Light2D>();
        globalUpper = globalLight.intensity;
        globalLower = 0f;
        
        playerLight = transform.Find("Player Light").GetComponent<Light2D>();
        playerUpper = playerLight.intensity + playerLightIncrease;
        playerLower = playerLight.intensity;
        
        radiusUpper = playerLight.pointLightOuterRadius + playerRadiusIncrease;
        radiusLower = playerLight.pointLightOuterRadius;

        enemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Global Light Trigger")
        {
            // isDim = true;
            StopAllCoroutines();
            enemyManager.StopSpawning();
            StartCoroutine(EnterMaze());
            // globalLight.intensity = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.name == "Global Light Trigger")
        {
            // isDim = false;
            StopAllCoroutines();
            enemyManager.StartSpawning();
            StartCoroutine(ExitMaze());
            // globalLight.intensity = globalUpper;
        }
    }

    IEnumerator EnterMaze()
    {
        while(globalLight.intensity > globalLower || playerLight.intensity < playerUpper || playerLight.pointLightOuterRadius < radiusUpper)
        {
            if(globalLight.intensity > globalLower) globalLight.intensity -= globalUpper * (Time.deltaTime / fadeTime);
            if(playerLight.intensity < playerUpper) playerLight.intensity += playerUpper * (Time.deltaTime / fadeTime);
            if(playerLight.pointLightOuterRadius < radiusUpper) playerLight.pointLightOuterRadius += radiusUpper * (Time.deltaTime / fadeTime);
            yield return null;
        }
        globalLight.intensity = globalLower;
        playerLight.intensity = playerUpper;
        playerLight.pointLightOuterRadius = radiusUpper;
        yield break;
    }

    IEnumerator ExitMaze()
    {
        
        while(globalLight.intensity < globalUpper || playerLight.intensity > playerLower || playerLight.pointLightOuterRadius > radiusLower)
        {
            if(globalLight.intensity < globalUpper) globalLight.intensity += globalUpper * (Time.deltaTime / fadeTime);
            if(playerLight.intensity > playerLower) playerLight.intensity -= playerUpper * (Time.deltaTime / fadeTime);
            if(playerLight.pointLightOuterRadius > radiusLower) playerLight.pointLightOuterRadius -= radiusUpper * (Time.deltaTime / fadeTime);
            yield return null;
        }
        globalLight.intensity = globalUpper;
        playerLight.intensity = playerLower;
        playerLight.pointLightOuterRadius = radiusLower;
        yield break;
    }
}
