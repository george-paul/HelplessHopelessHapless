using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isSpawningEnemies = true;
    public float spawnDelay;
    public GameObject enemyPrefab;
    private Transform player;
    private float radius;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        radius = Vector3.Distance(Camera.main.ViewportToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane)), Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,Camera.main.nearClipPlane)) );
        radius += 3;
        StartSpawning();
    }

    public void StartSpawning() {
        isSpawningEnemies = true;
        StartCoroutine(EnemySpawner());
    }

    public void StopSpawning() {
        isSpawningEnemies = false;
    }

    IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(spawnDelay);
        while(isSpawningEnemies)
        {
            
            Vector3 nextSpawnPoint = Random.onUnitSphere;
            nextSpawnPoint.z = 0;
            nextSpawnPoint.Normalize();
            nextSpawnPoint *= radius;
            nextSpawnPoint.x += player.position.x;
            nextSpawnPoint.y += player.position.y;
            // TODO: prevent spawning outside the walls (maybe just destroy enemies if outside walls)
            
            Instantiate(enemyPrefab, nextSpawnPoint, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnDelay);
        }
        yield break;
    }
}
