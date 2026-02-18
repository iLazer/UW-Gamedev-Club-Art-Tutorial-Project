using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPrefabsList;
    int index;
    [SerializeField] SpawnField spawnField;
    public float spawnInterval = 2f; // Time in seconds between spawns
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = spawnField.getRandomPos();
        Instantiate(spawnPrefabsList[index % spawnPrefabsList.Count], spawnPosition, Quaternion.identity);
        index++;
    }
}
