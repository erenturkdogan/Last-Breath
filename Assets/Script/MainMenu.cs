using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Oyun sahnenizin tam adı
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyun kapandı!"); // Editörde test ederken çalıştığını görmek için
    }
}