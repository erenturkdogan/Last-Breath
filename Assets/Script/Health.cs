using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    public HealthBar healthBar; // HealthBar referansı
    public GameObject losePanel; // Kaybetme paneli referansı

    void Start()
    {
        // Maksimum sağlık değerini başlangıçta ayarla
        healthBar.SetMaxHealth((int)maxHealth);
        healthBar.SetHealth((int)currentHealth);

        // Kaybetme panelini başlangıçta kapalı yap
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    public void ReduceHealth(float value)
    {
        currentHealth -= value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateUI();

        // Eğer sağlık 0'a düştüyse kaybetme ekranını göster
        if (currentHealth <= 0)
        {
            ShowLoseScreen();
        }
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

    void ShowLoseScreen()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(true); // Kaybetme panelini aktif et
            Time.timeScale = 0f; // Oyunu durdur
            // Game Over ekranını göster
            GameManager.instance.ShowGameOver();
        }
    }

    // Tekrar Oyna butonuna bağlı olacak
    public void RetryGame()
    {
        Time.timeScale = 1f; // Oyunu yeniden başlatırken zamanı normale döndür
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Şu anki sahneyi yeniden yükle
    }

    // Çıkış butonuna bağlı olacak
    public void QuitGame()
    {
        Debug.Log("Oyun kapatıldı!"); // Editor'da test için konsola mesaj yazdırır
        Application.Quit(); // Uygulamayı kapatır
    }
}
