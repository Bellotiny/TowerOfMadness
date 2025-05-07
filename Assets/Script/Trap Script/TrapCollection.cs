using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollection : MonoBehaviour
{
    public float pushForce = 5f;
    public int damageAmount = 20;

   private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Trap"))
    {
       
           Rigidbody playerRb = GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
                pushDirection.y = 0f; // stay horizontal
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }

            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

        
       
    }
}
}
