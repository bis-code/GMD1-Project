using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public Transform playerTransform;

    public float enemyInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 1f, enemyInterval);
    }

    private void spawnEnemy()
    {
        int rangeEnemy = Random.Range(0, enemyPrefabs.Length);
        int rangeSpawnPoint = Random.Range(0, spawnPoints.Length);
        
        //todo this is not called
        if (playerTransform.position.x > spawnPoints[rangeSpawnPoint].position.x)
        {
            Debug.Log("player x" + playerTransform.position.x);
            Debug.Log("enemy x" + spawnPoints[rangeSpawnPoint].position.x);
            return;
        }

        GameObject enemy = Instantiate(enemyPrefabs[rangeEnemy], spawnPoints[rangeSpawnPoint].position, transform.rotation);
    }
}
