using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ZombieMovement enemyPrefab;
    [SerializeField] private float delay;
    [SerializeField] private float leftRightDistance;
    [SerializeField] private float upDownDistance;
    [SerializeField] private Transform player;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delay, delay);
    }

    private Vector3 GetRandomPos()
    {
        float x = Random.Range(-leftRightDistance, leftRightDistance);
        float y = Random.Range(-upDownDistance, upDownDistance);
        return new Vector3(x, y, 10f);
    }

    private void SpawnEnemy()
    {
        ZombieMovement enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandomPos();
        enemy.SetTarget(player);
    }
}
