using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GetRandomPosition(), powerUpPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<Enemy4>(0).Length;
        if (enemyCount == 0)
        {
            Instantiate(powerUpPrefab, GetRandomPosition(), powerUpPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    

    void SpawnEnemyWave(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(enemyPrefab,GetRandomPosition(),enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }


}
