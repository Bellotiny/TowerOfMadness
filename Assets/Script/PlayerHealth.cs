using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TMP_Text healthTextUI; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        if (healthTextUI != null)
        {
            healthTextUI.text = "Health: " + currentHealth.ToString();
        }
    }
}
