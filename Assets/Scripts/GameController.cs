using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private GameObject enemyPrefab;
    private Vector3 spawnLocation;

    private Vector3 playerLocation;

    private float timeToSpawn = 0;
    private float enemySpawnTimer = 2;
    private float enemyCount = 0;
    private float waveSpawnTimer = 5;
    private float waveCount = 0;

    void Start()
    {
        enemyPrefab = (Resources.Load("Prefabs/Zombie")) as GameObject;
    }

    void Update()
    {
        if (enemyCount <= 0)
        {
            if (Time.time >= timeToSpawn)
            {
                SpawnWave();
            }
        }
    }

    void SpawnWave()
    {
        waveCount += 1;
        enemyCount = Random.Range(5, 31);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLocation = player.transform.position;

        for (int i = 0; i < enemyCount; i++)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector3 randomRangeFromPlayer = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            randomRangeFromPlayer *= Random.Range(22, 75);

            spawnLocation = playerLocation - randomRangeFromPlayer;

            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
    }

    public void EnemyDeath()
    {
        enemyCount -= 1;
        if (enemyCount <= 0)
        {
            timeToSpawn = Time.time + waveSpawnTimer;
        }
    }
}
