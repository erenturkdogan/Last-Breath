using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    public HealthBar healthBar; // HealthBar referansı

    void Start()
    {
        // Maksimum sağlık değerini başlangıçta ayarla
        healthBar.SetMaxHealth((int)maxHealth);
        healthBar.SetHealth((int)currentHealth);
    }

    public void ReduceHealth(float value)
    {
        currentHealth -= value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateUI();
    }

    public void IncreaseHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthBar.SetHealth((int)currentHealth); // Sağlık değerini slider'a aktar
    }
}
