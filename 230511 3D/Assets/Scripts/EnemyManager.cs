using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    float spawnTime = 3f;

    [SerializeField]
    GameObject Enemy;
    [SerializeField]
    Transform[] spawnPoints;

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Random.Range(0, spawnPoints.Length);
        Instantiate(Enemy, spawnPoints[spawnPointIndex]);
    }


    void Update()
    {
        
    }
   
}
