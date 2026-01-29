using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float leftRigthDistance;
    [SerializeField] private float upDownDistance;

    void Update()
    {
        Vector3 movement = new Vector3(player.position.x, player.position.y, transform.position.z);
        movement.x = Mathf.Clamp(movement.x, -leftRigthDistance, leftRigthDistance);
        movement.y = Mathf.Clamp(movement.y, -upDownDistance, upDownDistance);
        transform.position = movement;
    }
}
