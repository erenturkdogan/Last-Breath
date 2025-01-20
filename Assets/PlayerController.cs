using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Hareket hızı
    public float jumpForce = 5f; // Zıplama gücü

    private Animator animator;
    private CharacterController characterController;
    private float multiplier = 1;

    void Start()
    {
        // Animator ve CharacterController bileşenlerini al
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Hareket girdilerini al
        float move = Input.GetAxis("Vertical");  // İleri-geri hareket
        float strafe = Input.GetAxis("Horizontal");  // Sağa-sola hareket

        multiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

        // Hareket vektörü
        //Vector3 movement = new Vector3(strafe, 0, move) * speed * Time.deltaTime;
        //characterController.Move(transform.TransformDirection(movement));

        // Animator parametrelerini güncelle
        animator.SetFloat("ver", move * multiplier); // Speed parametresi
        animator.SetFloat("hor", strafe * multiplier); 

        // Zıplama
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            animator.SetTrigger("Jump"); // Jump tetiklenir
        }
    }
}