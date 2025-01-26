using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    public float damage = 25f;         // Silahýn hasar gücü
    public float range = 50f;          // Atýþ menzili
    public int maxAmmo = 10;           // Þarjör kapasitesi
    public float reloadTime = 2f;      // Þarjör doldurma süresi
    public ParticleSystem muzzleFlash; // Ateþ efekti (Particle)
    public Camera fpsCamera;           // FPS kamerasý

    private int currentAmmo;           // Mevcut mermi sayýsý
    private bool isReloading = false;  // Þarjör doldurma kontrolü

    void Start()
    {
        currentAmmo = maxAmmo; // Ýlk baþta tüm mermiler dolu
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetButtonDown("Fire1")) // Sol týk ile ateþ etme
        {
            Shoot();
        }

        if (currentAmmo <= 0) // Þarjör biterse doldur
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0) return; // Mermi yoksa ateþ etme

        muzzleFlash.Play();           // Ateþ efekti
        currentAmmo--;                // Mermiyi azalt

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log("Vurulan obje: " + hit.transform.name); // Vurulan objeyi göster

            // Eðer vurulan obje bir zombi ise
            ZombieHealth zombie = hit.transform.GetComponent<ZombieHealth>();
            if (zombie != null)
            {
                Debug.Log("Zombi hasar aldý!");  // Zombi hasar aldýysa bunu da konsolda görelim
                zombie.TakeDamage(damage); // Zombiye hasar ver
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime); // Þarjör doldurma süresi
        currentAmmo = maxAmmo;                      // Þarjörü doldur
        isReloading = false;
    }
}
