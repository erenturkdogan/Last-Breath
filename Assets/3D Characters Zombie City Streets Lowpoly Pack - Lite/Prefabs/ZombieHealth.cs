using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // Zombinin maksimum caný
    private float currentHealth;     // Mevcut can

    void Start()
    {
        currentHealth = maxHealth;   // Baþlangýçta tam canla baþla
        UpdateHealthStatus();        // Baþlangýçta can bilgisini yazdýr
    }

    // Hasar aldýðýnda çaðrýlýr
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;    // Hasar miktarýný canýndan çýkar

        Debug.Log(gameObject.name + " hasar aldý! Mevcut can: " + currentHealth);  // Hasar aldýktan sonra mevcut caný konsola yazdýr

        // Eðer can sýfýr veya altýna düþerse
        if (currentHealth <= 0f)
        {
            Die();                  // Zombi ölür
        }
    }

    // Zombi öldüðünde yapýlacaklar
    void Die()
    {
        Debug.Log(gameObject.name + " öldü!");  // Konsola zombi öldü yazdýr
        Destroy(gameObject);         // Zombiyi sahneden kaldýr
    }

    // Can durumunu konsola yazdýr
    void UpdateHealthStatus()
    {
        Debug.Log(gameObject.name + " baþlangýç caný: " + currentHealth);  // Baþlangýçta can durumunu yazdýr
    }
}
