using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] SpawnField spawnField;
    public float spawnInterval = 2f; // Time in seconds between spawns
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = spawnField.getRandomPos();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
