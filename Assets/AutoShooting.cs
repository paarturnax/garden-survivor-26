using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;

    [SerializeField] private int bullets;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (bullets > 0 && timer >= cooldown)
        {
            ZombieMovement zombie = FindNearesZombie();
            Shoot(zombie);
            timer = 0f;
            bullets--;
        }
    }

    private void Shoot(ZombieMovement zombie)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        Setup(projectile.transform, zombie.transform);
    }

    private void Setup(Transform projectile, Transform zombie)
    {
        projectile.position = transform.position;
        Vector3 direction = zombie.position - transform.position;
        projectile.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    private ZombieMovement FindNearesZombie()
    {
        Vector3 position = transform.position;
        if (EnemySpawner.SpawnedZombies.Count == 0)
        {
            return null;
        }

        ZombieMovement nearest = EnemySpawner.SpawnedZombies[0];
        float minDistance = Vector3.Distance(position, nearest.transform.position);
        for (int i = 1; i < EnemySpawner.SpawnedZombies.Count; i++)
        {
            ZombieMovement zombie = EnemySpawner.SpawnedZombies[i];
            float distance = Vector3.Distance(position, zombie.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = zombie;
            }
        }
        return nearest;
    }
}
