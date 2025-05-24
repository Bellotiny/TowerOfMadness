using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollection : MonoBehaviour
{
    
    public float pushForce = 5f;
    private int plantTrapDamage = 5;
    private int normalTrapDamage = 10;
    private int fireTrapDamage = 5;

    private void ApplyDamageAndPush(GameObject trapObject)
    {
        Rigidbody playerRb = GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            Vector3 pushDirection = (transform.position - trapObject.transform.position).normalized;
            pushDirection.y = 0f;
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            int damage = GetDamageBasedOnTrap(trapObject);
            playerHealth.TakeDamage(damage);
        }
    }

    private int GetDamageBasedOnTrap(GameObject trap)
    {
        if (trap.CompareTag("PlantTrap"))
        {
            return plantTrapDamage;
        }
        else if (trap.CompareTag("FireTrap"))
        {
            return fireTrapDamage;
        }
        else if (trap.CompareTag("Trap"))
        {
            return normalTrapDamage;
        }

        return 0; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("PlantTrap") || collision.gameObject.CompareTag("FireTrap"))
        {
            ApplyDamageAndPush(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap") || other.CompareTag("PlantTrap") || other.CompareTag("FireTrap"))
        {
            ApplyDamageAndPush(other.gameObject);
        }
    }
}
