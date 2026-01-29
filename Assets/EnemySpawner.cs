using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float dalay;
    [SerializeField] private float leftRightDistance;
    [SerializeField] private float upDownDistance;
    void Start()
    {
        
    }

    private Vector3 GetRandomPos()
    {
        float x = Random.Range(-leftRightDistance, leftRightDistance);
        float y = Random.Range(-upDownDistance, upDownDistance);
        return new Vector3(x, y, 10f);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
    }
}
