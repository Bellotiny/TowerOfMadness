using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTrigger : MonoBehaviour
{
    public float pushForce = 5f;
    public float downwardForce = 5f;
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] barsToFall = GameObject.FindGameObjectsWithTag("Frontbar");
            Debug.Log("Triggered! Found " + barsToFall.Length + " bars.");

            foreach (GameObject bar in barsToFall)
            {
                Rigidbody rb = bar.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;

                    //rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
                    Vector3 forceDirection = (-bar.transform.up + bar.transform.right).normalized;

                    // Apply the force as an impulse for an immediate push
                    rb.AddForce(forceDirection * pushForce + Vector3.down * downwardForce, ForceMode.Impulse);
                }
            }
        }
    }
}
