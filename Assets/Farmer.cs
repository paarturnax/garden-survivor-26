using Unity.VisualScripting;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField] private int hp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);
            hp -= 1;
            print($"HP: {hp}");
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }    
}
