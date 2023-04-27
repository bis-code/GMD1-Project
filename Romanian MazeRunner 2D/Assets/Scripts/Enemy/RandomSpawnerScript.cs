using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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

    private bool checkWithinRange(Transform t1, Transform t2, float distance)
    {
        return Vector2.Distance(t1.position, t2.position) < distance;
    }
    
    private void spawnEnemy()
    {
        int rangeEnemy = Random.Range(0, enemyPrefabs.Length);
        int rangeSpawnPoint = Random.Range(0, spawnPoints.Length);
        
        //todo this is not called
        if (playerTransform.position.x > spawnPoints[rangeSpawnPoint].position.x && !checkWithinRange(playerTransform,spawnPoints[rangeSpawnPoint],3))
        {
            Debug.Log("player x" + playerTransform.position.x);
            Debug.Log("enemy x" + spawnPoints[rangeSpawnPoint].position.x);
            return;
        }

        GameObject enemy = Instantiate(enemyPrefabs[rangeEnemy], spawnPoints[rangeSpawnPoint].position, transform.rotation);
    }
}
