using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //animator.SetTrigger("GotHit");
        Debug.Log("Spider Got Hit!!");
        Debug.Log("Spider Health: " + currentHealth);
        //healthbar.value = currentHealth;
        if(currentHealth <= 0){
            Die();
        }
    }
    public void Die(){
        animator.SetTrigger("Die");
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
