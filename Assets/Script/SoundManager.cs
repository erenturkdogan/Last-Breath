using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundSound;
    public Button playButton;

    void Start()
    {
        // Ses dosyasını AudioSource'a bağla ve çalmaya başla
        audioSource.clip = backgroundSound;
        audioSource.Play();

        // Play butonuna tıklandığında sesi durdur
        playButton.onClick.AddListener(StopSound);
    }

    void StopSound()
    {
        audioSource.Stop();
    }
}