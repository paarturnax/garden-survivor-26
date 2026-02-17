using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField] private int hp;
    private int loot = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);
        }

    }
}
