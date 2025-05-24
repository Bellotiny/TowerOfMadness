using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    private float playerHitCooldown = 1.0f;
    private float lastHitTime = -Mathf.Infinity;
    private AudioSource audioSource;
    public AudioClip swordSound;

    private EnemyController parentEnemyController;
    //private EnemyController enemyController;

    private void Start()
    {
        parentEnemyController = GetComponentInParent<EnemyController>();
        //enemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (other.CompareTag("Enemy"))
        {
            EnemyController ec = other.GetComponentInParent<EnemyController>();
            MobEnemyController mec = other.GetComponentInParent<MobEnemyController>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);
                audioSource.PlayOneShot(swordSound);
            }
            else
            {
                Debug.Log("Missing enemy health!!!");
            }
            if (ec != null)
            {
                ec.GotHit();
            }
            else if (mec != null)
            {
                mec.GotHit();
            }
            else
            {
                Debug.LogWarning("No valid enemy controller (Boss or Mob) found!");
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
