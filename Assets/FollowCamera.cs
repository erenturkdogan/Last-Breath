using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;  // Takip edilecek hedef (karakter)
    public Vector3 offset;    // Kamera ile hedef arasındaki mesafe

    // LateUpdate, kameranın hareketi tamamlandıktan sonra çalışır, böylece kameranın karakteri takip etmesi sağlanır.
    void LateUpdate()
    {
        transform.position = target.position + offset;  // Kameranın konumunu ayarla
        transform.LookAt(target);  // Kamerayı hedefe doğru çevir
    }
}
