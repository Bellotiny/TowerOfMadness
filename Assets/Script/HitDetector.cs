using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth =  other.GetComponent<EnemyHealth>();
            EnemyController enemyController =  other.GetComponent<EnemyController>();
            if (enemyController  != null)
            {
                enemyController.GotHit();
            }
        }
         if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth =  other.GetComponent<PlayerHealth>();
            if (playerHealth  != null)
            {
                playerHealth.TakeDamage(15);
            }
        }
    }
}
