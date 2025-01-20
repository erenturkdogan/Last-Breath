using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public void ReduceHealth (float value)
    {
        currentHealth -= value;
        if(currentHealth <0)
        {
            currentHealth = 0;
        }
        UpdateUI();
    }
    public void IncreaseHealth (float value)
    {
        currentHealth += value;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateUI();
    }
    public void UpdateUI ()
    {

    }
}
