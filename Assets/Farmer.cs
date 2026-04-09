using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private LevelUI levelUI;
    private ParticleSystem ps;
    public int Bullets;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    public void UpdateBullets()
    {
        Bullets--;
        levelUI.UpdateBullets(Bullets);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            TakeDamage(zombie.Damage);
            Destroy(collision.gameObject);
            ps.Play();
        }
    }
    
    private void TakeDamage(int damage)
    {
        if (damage > hp)
        {
            damage = hp;
        }
        hp -= damage;
        healthUI.UpdateHP(hp);
    }
}
