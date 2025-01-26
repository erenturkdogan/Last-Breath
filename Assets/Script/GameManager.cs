using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider için gerekli
using TMPro; // TextMeshPro için gerekli

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<string> collectedPapers = new List<string>();

    // UI elemanları
    [SerializeField] private Slider progressBar; // Bar referansı
    [SerializeField] private int totalPaperCount = 5; // Toplam kağıt sayısı
    [SerializeField] private GameObject gameOverPanel; // Game Over panelinin referansı
    [SerializeField] private GameObject winPanel; // Kazanma paneli
    [SerializeField] private AudioSource backgroundMusic; // Arka plan müziği için AudioSource

    private void Awake()
    {
        // Singleton kontrolü
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CollectPaper(string paperName)
    {
        if (!collectedPapers.Contains(paperName))
        {
            collectedPapers.Add(paperName);
            Debug.Log($"Kağıt toplandı: {paperName}");

            // Bar'ı güncelle
            UpdateProgressBar();
        }
        else
        {
            Debug.Log($"Bu kağıt zaten toplandı: {paperName}");
        }
    }

    private void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = collectedPapers.Count;

            // Eğer tüm kağıtlar toplandıysa, kazandınız ekranını göster
            if (collectedPapers.Count >= totalPaperCount)
            {
                Debug.Log("Tüm kağıtlar toplandı! Görev tamamlandı!");
                
                // Kazanma mesajını göster
                ShowWinScreen();
            }
        }
        else
        {
            Debug.LogError("ProgressBar referansı eksik!");
        }
    }

    // Kazanma ekranını gösteren fonksiyon
    public void ShowWinScreen()
    {
        // Kazanma panelini aktif et
        winPanel.SetActive(true);

        // Arka plan müziğini durdur
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Oyun zamanını durdur
        Time.timeScale = 0f; // Oyunun durmasını sağlar

        // Fareyi görünür hale getir
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Fareyi ekrana ortalamak
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Game Over ekranını açan fonksiyon
    public void ShowGameOver()
    {
        // Game Over Panelini Göster
        gameOverPanel.SetActive(true);

        // Fareyi Görünür ve Serbest Bırak
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Fareyi ekrana ortalamak
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
