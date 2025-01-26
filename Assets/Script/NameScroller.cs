using System.Collections;
using UnityEngine;
using TMPro;

public class NameScroller : MonoBehaviour
{
    public TextMeshProUGUI namesText; // İsimlerin TextMeshPro referansı
    public float scrollSpeed = 50f; // Kaydırma hızı

    private RectTransform rectTransform;

    private void Start()
    {
        // RectTransform'u al
        rectTransform = namesText.GetComponent<RectTransform>();
        // İsimleri kaydırmak için coroutine başlat
        StartCoroutine(ScrollNames());
    }

    private IEnumerator ScrollNames()
    {
        // Ekranın sağ dışından başlayıp, sola kayacak şekilde başlatıyoruz.
        Vector3 startPosition = new Vector3(Screen.width, rectTransform.position.y, rectTransform.position.z);
        Vector3 endPosition = new Vector3(-Screen.width, rectTransform.position.y, rectTransform.position.z);

        // İlk başta ismin sağdan sola kaymasını sağla
        rectTransform.position = startPosition;

        while (true)
        {
            // Kayma işlemi başlat
            float time = 0f;
            while (time < 1f)
            {
                time += Time.deltaTime * scrollSpeed;
                rectTransform.position = Vector3.Lerp(startPosition, endPosition, time);
                yield return null;
            }

            // Sol tarafa kaydıktan sonra ismin geri sağa kaymasını sağla
            rectTransform.position = endPosition;
            startPosition = new Vector3(-Screen.width, rectTransform.position.y, rectTransform.position.z);
            endPosition = new Vector3(Screen.width, rectTransform.position.y, rectTransform.position.z);
        }
    }
}
