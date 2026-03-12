using UnityEngine;

public class MouseShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int bullets;
    [SerializeField] private Camera _camera;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bullets > 0)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 point = _camera.ScreenToWorldPoint(mousePos);
            point.z = 0f;
            bullets--;
            Shoot(point);
        }
    }
    private void Shoot(Vector3 target)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
        Vector3 direction = target - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
        projectile.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
