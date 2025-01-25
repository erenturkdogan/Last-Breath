using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera; // Oyuncunun kamerası
    public float interactionDistance = 3f; // Etkileşim mesafesi
    public KeyCode interactKey = KeyCode.E; // Etkileşim tuşu

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            CheckForInteractable();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("PaperPiece"))
            {
                hit.collider.GetComponent<PaperPiece>()?.Collect();
            }
        }
    }
}
