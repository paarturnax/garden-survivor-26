using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private SpriteRenderer sr;
    private Transform player;

    public void SetTarget(Transform trarget)
    {
        player = trarget;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, movement);
        sr.flipX = transform.position.x > player.position.x;
    }
}
