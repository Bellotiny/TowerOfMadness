using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollection : MonoBehaviour
{
    public float pushForce = 5f;

   private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Trap"))
    {
        Rigidbody playerRb = GetComponent<Rigidbody>();
        if (playerRb != null)
        {
             // Stop all current velocity
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;

                // Push the player away from the trap
                Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
                pushDirection.y = 0f; // stay horizontal
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
}
