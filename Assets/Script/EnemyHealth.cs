using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    private int currentHealth;
    // public Slider healthbar;
    
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        // healthbar.maxValue = maxHealth;
        // healthbar.value = currentHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Vector3 randomness = new Vector3(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f));
        DamagePopUpGenerator.current.CreatePopUp(transform.position + randomness, damage.ToString(), Color.red);
        //animator.SetTrigger("GotHit");
        // Debug.Log("Spider Got Hit!!");
        // Debug.Log("Spider Health: " + currentHealth);
        //healthbar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            UnityEngine.Debug.Log("No animator found for enemy");
        }
        
    }
    public void OnDeathAnimationEnd()
    {
        if (TryGetComponent<MobEnemyController>(out var mob))
        {
            MobEnemyController.activeMobs.Remove(mob);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
