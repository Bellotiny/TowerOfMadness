using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    //public TMP_Text healthTextUI; 

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        if (animator == null){
            Debug.LogError("Animator component missing!");
        }
    }
    void Update(){
        if(currentHealth <= 0){
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        animator.SetTrigger("GotHit");
        //UpdateHealthText();
    }

    public void Die(){
        animator.SetTrigger("Die");
        if(GameManager.Instance != null){
            GameManager.Instance.HandleCurrentLevelFailure();
        }
    }

    // public void Heal(int amount)
    // {
    //     currentHealth += amount;
    //     currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    //     UpdateHealthText();
    // }

    // void UpdateHealthText()
    // {
    //     if (healthTextUI != null)
    //     {
    //         healthTextUI.text = "Health: " + currentHealth.ToString();
    //     }
    // }
}
