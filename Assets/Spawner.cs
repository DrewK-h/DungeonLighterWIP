using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// The logic for the enemy spawning is heavily influenced by a lot of youtube videos,
/// I watched a couple of videos on enemy spawning and found a simple way to spawn an enemy randomly on the edge of a circle
/// In the future I might try to add edge based spawning or maybe spawning inside the room with an animation, but for now I kept it simple
public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int baseEnemiesPerWave = 5;
    public float timeBetweenEnemies = 0.5f;
    public float timeBetweenWaves = 4f;

    public Transform spawnCenter;
    public float spawnRadius = 10f;
    private int currentWave = 1;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        while (true)
        {
            int enemyCount = baseEnemiesPerWave * currentWave;

            for (int i = 0; i < enemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;
        }
    }
    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)spawnCenter.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}