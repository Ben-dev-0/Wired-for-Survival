using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] healthIcons;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                healthIcons[i].sprite = fullHeart;
            }
            else
            {
                healthIcons[i].sprite = emptyHeart;
            }
        }
    }
}
