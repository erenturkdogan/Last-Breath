using UnityEngine;

public class PaperPiece : MonoBehaviour
{
    public string paperName; // Kağıt parçasının ismi
    public AudioClip collectSound; // Toplama sesi
    public GameObject collectEffectPrefab; // Efekt prefab'ı

    public void Collect()
    {
        // Toplama sesi çal
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Debug.Log($"{paperName} toplandı!");

        // Efekti oluştur
        if (collectEffectPrefab != null)
        {
            // Efekt, kağıdın bulunduğu konumda oynatılacak
            Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
        }

        // Kağıt parçasını GameManager'a bildir
        GameManager.instance.CollectPaper(paperName);

        // Kağıt objesini yok et
        Destroy(gameObject);
    }
}
