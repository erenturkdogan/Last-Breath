using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider için gerekli

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<string> collectedPapers = new List<string>();

    // UI elemanları
    [SerializeField] private Slider progressBar; // Bar referansı
    [SerializeField] private int totalPaperCount = 5; // Toplam kağıt sayısı

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

            // Eğer tüm kağıtlar toplandıysa, bitiş işlemi yapılabilir
            if (collectedPapers.Count >= totalPaperCount)
            {
                Debug.Log("Tüm kağıtlar toplandı! Görev tamamlandı!");
                // Burada istediğiniz bitiş mekaniklerini ekleyebilirsiniz
            }
        }
        else
        {
            Debug.LogError("ProgressBar referansı eksik!");
        }
    }
}
