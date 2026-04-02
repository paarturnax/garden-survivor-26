using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ZombieMovement enemyPrefab;
    [SerializeField] private float delay;
    [SerializeField] private float leftRightDistance;
    [SerializeField] private float upDownDistance;
    [SerializeField] private Transform player;

    // Список заспавненных зомби
    private static List<ZombieMovement> spawnedZombies = new List<ZombieMovement>();
    public static List<ZombieMovement> SpawnedZombies => spawnedZombies;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delay, delay);
    }

    private Vector3 GetRandomPos()
    {
        float x = Random.Range(-leftRightDistance, leftRightDistance);
        float y = Random.Range(-upDownDistance, upDownDistance);
        return new Vector3(x, y, 0f);
    }

    private void SpawnEnemy()
    {
        ZombieMovement enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandomPos();
        enemy.SetTarget(player);
        spawnedZombies.Add(enemy);
    }

    public static void Remove(ZombieMovement zombie)
    {
        spawnedZombies.Remove(zombie);
    }
}
