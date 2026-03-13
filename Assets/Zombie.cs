using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage => damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject); // уничтожаем снаряд
            Destroy(gameObject);           // уничтожаем сами себя (зомби)
        }
    }
}
