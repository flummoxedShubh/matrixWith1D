using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemy0;
    public Transform enemy1;

    public float timeBetweenSpawns = 0.1f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", timeBetweenSpawns, timeBetweenSpawns);   
    }

    void SpawnEnemy()
    {
        float randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            Instantiate(enemy0, transform.position, Quaternion.identity);
        }
        else if (randomNum == 1)
        {
            Instantiate(enemy1, transform.position, Quaternion.identity);
        }
        
    }
    
}
