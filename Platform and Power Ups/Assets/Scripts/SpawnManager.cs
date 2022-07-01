using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCounter;
    public int enemiesSpawnCounter = 1;

    void Start()
    {
        Spawn(enemyPrefab, enemiesSpawnCounter);
        Spawn(powerUpPrefab, 1);
    }

    void Update()
    {
        enemyCounter = GameObject.FindObjectsOfType<Enemy>().Length;

        if(enemyCounter <= 0)
        {
            enemiesSpawnCounter++;
            Spawn(enemyPrefab, enemiesSpawnCounter);
            Spawn(powerUpPrefab, 1);
        }
    }

    void Spawn(GameObject obj, int quantity)
    {
        for(int i=0; i<quantity; i++)
        {
            Instantiate(obj, GetRandomPosition(), obj.transform.rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randonX = Random.Range(-9, 9);
        float randonZ = Random.Range(-9, 9);

        return new Vector3(randonX, 0, randonZ);
    }
    
}
