using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject enemyPrefab;
    private Vector3 spawnLocation;

    private Vector3 playerLocation;

    private float timeToSpawn = 0f;
    private float enemySpawnTimer = 2f;
    private float enemyCount = 0f;
    private float waveSpawnTimer = 5f;
    private float waveCount = 0f;

    void Start() {

        enemyPrefab = (Resources.Load("Prefabs/Zombie")) as GameObject;
    }

    void Update() {

        if (enemyCount <= 0f) {
            if (Time.time >= timeToSpawn) {
                SpawnWave();
            }
        }
    }

    void SpawnWave() {

        waveCount += 1f;
        enemyCount = Random.Range(5, 31);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLocation = player.transform.position;

        for (int i = 0; i < enemyCount; i++) {

            float angle = Random.Range(0f, Mathf.PI * 2);
            Vector3 randomRangeFromPlayer = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            randomRangeFromPlayer *= Random.Range(22f, 75f);

            spawnLocation = playerLocation - randomRangeFromPlayer;

            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);          
        }
    }

    void EnemyDeath() {

        enemyCount -= 1f;
        if (enemyCount <= 0f)
        {
            timeToSpawn = Time.time + waveSpawnTimer;
        }

    }
}
