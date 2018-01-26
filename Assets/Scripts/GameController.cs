using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private float EnemyCount { get; set; }
    private float WaveCount { get; set; }

    private float timeToSpawn;
    private float spawnTimer = 5;

    private GameObject enemyPrefab;

    void Awake()
    {
        enemyPrefab = (Resources.Load("Prefabs/Zombie")) as GameObject;
    }

    void Update()
    {
        if (EnemyCount <= 0)
        {
            if (Time.time >= timeToSpawn)
            {
                SpawnWave();
            }
        }
    }

    void SpawnWave()
    {
        WaveCount += 1;
        EnemyCount = Random.Range(5, 16);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLocation = player.transform.position;

        for (int i = 0; i < EnemyCount; i++)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector3 randomRangeFromPlayer = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            randomRangeFromPlayer *= Random.Range(25, 60);

            Vector3 spawnLocation = playerLocation - randomRangeFromPlayer;

            GameObject enemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
    }

    public void EnemyDeath()
    {
        EnemyCount -= 1;

        if (EnemyCount <= 0)
        {
            timeToSpawn = Time.time + spawnTimer;
        }
    }
}
