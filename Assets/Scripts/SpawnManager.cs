using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private int prefabIndex;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9;
    public int countEnemies;
    public int waveNumber = 1;
    
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        var enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        var hardEnemy = GameObject.FindGameObjectsWithTag("Hard Enemy").Length;
        countEnemies = enemy + hardEnemy;
        if (countEnemies == 0)
        {
            waveNumber += 1;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPosition;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i += 1)
        {
            prefabIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[prefabIndex], GenerateSpawnPosition(), enemyPrefabs[prefabIndex].transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
    }
}
