using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun transform'u
    private NavMeshAgent agent;

    void Start()
    {
        // NavMeshAgent bileşenini al
        agent = GetComponent<NavMeshAgent>();

        // Oyuncuyu otomatik bul (eğer bir Tag atanmışsa)
        if (player == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Oyuncunun pozisyonuna doğru hareket et
            agent.SetDestination(player.position);
        }
    }
}