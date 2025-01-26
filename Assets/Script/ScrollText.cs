using UnityEngine;

public class HorizontalScrollText : MonoBehaviour
{
    public float scrollSpeed = 200f; // Kayma hızı (piksel/saniye)
    private RectTransform rectTransform;

    // 1920x1080 çözünürlüğüne göre pozisyon değerleri
    private float resetPositionX = -1000f; // Yazının ekranın sol dışından başlayacağı nokta
    private float endPositionX = 1000f;   // Yazının ekranın sağ dışına çıkacağı nokta

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Başlangıç pozisyonunu ayarla
        rectTransform.anchoredPosition = new Vector2(resetPositionX, rectTransform.anchoredPosition.y);
    }

    void Update()
    {
        // Yazıyı X ekseninde sağa doğru hareket ettir
        rectTransform.anchoredPosition += new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Eğer yazı sağdan çıkarsa tekrar sola döndür
        if (rectTransform.anchoredPosition.x >= endPositionX)
        {
            rectTransform.anchoredPosition = new Vector2(resetPositionX, rectTransform.anchoredPosition.y);
        }
    }
}
