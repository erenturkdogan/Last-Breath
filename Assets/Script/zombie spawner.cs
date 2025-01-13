using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Zombinin prefab'ı
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Spawn bölgesinin boyutu
    public int spawnCount = 5; // Kaç tane zombi spawn edilecek
    public float spawnInterval = 2f; // Spawn aralıkları (saniye)
    public float spawnDelay = 15f; // Oyun başladıktan sonra spawn gecikmesi (saniye)

    private bool spawningEnabled = false; // Spawn işlemi başlatıldı mı?

    void Start()
    {
        // Spawn işlemini gecikmeli başlat
        Invoke(nameof(StartSpawning), spawnDelay);
    }

    void StartSpawning()
    {
        spawningEnabled = true;
        InvokeRepeating(nameof(SpawnZombie), 0f, spawnInterval);
    }

    void SpawnZombie()
    {
        if (!spawningEnabled) return;

        for (int i = 0; i < spawnCount; i++)
        {
            // Rastgele bir pozisyon oluştur
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            // Dünya koordinatlarına çevirmek için spawner objesinin pozisyonunu ekleyin
            Vector3 spawnPosition = transform.position + randomPosition;

            // Zombiyi oluştur
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Spawn alanını görselleştir
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
