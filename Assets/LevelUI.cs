using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletCount;
    [SerializeField] TextMeshProUGUI zombieCount;

    public void UpdateBullets(int count)
    {
        bulletCount.text = $"{count}";
    }

    public void UpdateKilledZombies(int count)
    {
        zombieCount.text = $"{count}";
    }

}
