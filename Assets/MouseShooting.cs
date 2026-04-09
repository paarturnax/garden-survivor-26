using UnityEngine;
using UnityEngine.Audio;

public class MouseShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Camera _camera;

    private SpriteRenderer sr;
    private Farmer player;
    private AudioSource audioSource;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Farmer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && player.Bullets > 0)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 point = _camera.ScreenToWorldPoint(mousePos);
            point.z = 0f;
            player.UpdateBullets();
            audioSource.Play();
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
        sr.flipY = Mathf.Abs(transform.rotation.z) > 0.5;
    }
}
