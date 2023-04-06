using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave 
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota; // tong so ke dich se spawn trong wave
        public float spawnInterval;// khoang thoi gian dich se spawn
        public int spawnCount;// tong so dich da spawn duoc trong wave
    }

    [System.Serializable]
    public class EnemyGroup 
    {
        public string enemyName; 
        public int enemyCount;//so luong ke dich se spawn
        public int spawnCount;//so luong cua loai ke dich da spawn trong wave
        public GameObject enemyPrefab;
    }
    public List<Wave> waves;// list cac wave co trong game
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    public float waveInterval;

    [Header("Spawn Position")]
    public List<Transform> relativesSpawnPoints;

    Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;

        CalculatedWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) {
            StartCoroutine(BeginNextWave());
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }
    IEnumerator BeginNextWave() {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < waves.Count - 1) {
            currentWaveCount++;
            CalculatedWaveQuota();
        }
    }
    void CalculatedWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups) {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }
    void SpawnEnemies()
    {
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota) {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups) {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount) {

                    if (enemiesAlive >= maxEnemiesAllowed) {

                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativesSpawnPoints[Random.Range(0, relativesSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;

                    enemiesAlive++;
                }
            }
        }

        if (enemiesAlive < maxEnemiesAllowed) {

            maxEnemiesReached = false;
        }
    
    }
    public void OnEnemyKilled() {

        enemiesAlive--;
    }
}
