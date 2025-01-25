using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenManager : MonoBehaviour
{
    public GameObject losePanel; // Panel objesini burada referans alacağız.

    void Start()
    {
        // Başlangıçta paneli kapatıyoruz
        losePanel.SetActive(false);
    }

    // Kaybetme durumunda bu fonksiyonu çağırın
    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdur
    }

    // Tekrar oyna butonunun fonksiyonu
    public void RetryGame()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Şu anki sahneyi yeniden yükle
    }

    // Çıkış butonunun fonksiyonu
    public void QuitGame()
    {
        Application.Quit();
    }
}
