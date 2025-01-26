using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Button için gerekli

public class WinManager : MonoBehaviour
{
    public GameObject winPanel; // Kazanma paneli
    public Button quitButton; // Çıkış butonu

    private void Start()
    {
        // Paneli başlangıçta kapalı tut
        winPanel.SetActive(false);

        // Çıkış butonuna işlev ekle
        quitButton.onClick.AddListener(QuitGame);
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true); // Kazanma panelini aç

        // Fareyi serbest bırak ve görünür yap
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void QuitGame()
    {
        // Oyunu kapat
        Debug.Log("Oyun kapatıldı!");
        Application.Quit(); // Uygulama kapanır
    }
}
