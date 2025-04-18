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
        animator.SetTrigger("GotHit");
        //healthbar.value = currentHealth;
        if(currentHealth <= 0){
            Die();
        }
    }

    public void Die(){
        if(GameManager.Instance != null){
            GameManager.Instance.RestartGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
