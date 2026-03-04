using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] images;

    public void UpdateHP(int hp)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i < hp);
        }
    }
}
