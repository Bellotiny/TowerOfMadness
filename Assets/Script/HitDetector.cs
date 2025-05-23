using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    private float playerHitCooldown = 1.0f;
    private float lastHitTime = -Mathf.Infinity;

    private EnemyController parentEnemyController;
    private EnemyController enemyController;

    private void Start()
    {
        parentEnemyController = GetComponentInParent<EnemyController>();
        enemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (other.CompareTag("Enemy"))
        {
            if (enemyController != null)
            {
                enemyController.GotHit();
                enemyHealth.TakeDamage(25);
            }
        }

        if (other.CompareTag("Player"))
        {
            if (Time.time - lastHitTime < playerHitCooldown) return;

            if (playerHealth != null)
            {
                if (parentEnemyController != null)
                {
                    if (parentEnemyController.isMob)
                    {
                        Debug.Log("It's a Mob!");
                        playerHealth.TakeDamage(10);
                    }
                    else
                    {
                        Debug.Log("It's a Boss!");
                        playerHealth.TakeDamage(25);
                    }
                }
                else
                {
                    Debug.Log("There is no Enemy Controller!");
                }

                lastHitTime = Time.time;
            }
        }
    }
}
