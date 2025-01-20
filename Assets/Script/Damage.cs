using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 5;

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.collider.tag);
        if (other.collider.tag == "Player")
        {
            other.collider.GetComponent<Health>().ReduceHealth(damageAmount);
        }
    }
}
