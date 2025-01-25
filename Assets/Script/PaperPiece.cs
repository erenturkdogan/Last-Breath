using UnityEngine;

public class PaperPiece : MonoBehaviour
{
    public string paperName; // Kağıt parçasının ismi
    public AudioClip collectSound; // Toplama sesi

    public void Collect()
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Debug.Log($"{paperName} toplandı!");
        GameManager.instance.CollectPaper(paperName);
        Destroy(gameObject); // Kağıt parçasını yok et
    }
}
