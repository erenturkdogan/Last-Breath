using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource musicSource; // Müzik kaynağını atayın

    void Awake()
    {
        // Müzik kaynağının oyun sahneleri arasında kaybolmaması için
        DontDestroyOnLoad(this);
        
        // Eğer başka bir MusicHandler varsa, bu objeyi yok et
        if (FindObjectsOfType<MusicHandler>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (musicSource != null)
        {
            // Müzik kaynağı varsa, müziği çalmaya başla
            musicSource.Play();
        }
        else
        {
            // Müzik kaynağı yoksa, hata mesajı ver
            Debug.LogError("MusicSource is not assigned!");
        }
    }

    public void RestartMusic()
    {
        if (musicSource != null)
        {
            // Müzik çalmayı durdur
            musicSource.Stop();

            // Müzik kaynağını sıfırla (isteğe bağlı)
            musicSource.time = 0;

            // Müzik tekrar başlasın
            musicSource.Play();
        }
        else
        {
            Debug.LogError("MusicSource is not assigned!");
        }
    }
}