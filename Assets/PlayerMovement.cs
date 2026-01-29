using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = GetMovementFromInput() * speed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetBool("isRun", movement.magnitude > 0);
    }

    private Vector2 GetMovementFromInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        return movement;
    }
}
