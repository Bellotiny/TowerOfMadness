using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
     [Header("UI Elements")]
     public TextMeshProUGUI foodText;
    public TextMeshProUGUI livesText;
    public Slider healthSlider;

    private CharacterMovement playerMovement;
    public bool isPlaying = true;
    //private float timePlayed = 0f;
    //public float totalTimePlayed = 0f;

    private bool isPickupTextActive = false;

     private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {//&& TrapManager.Instance != null
        if (ScoreManager.Instance != null )
        {
            FindPlayer();
            ScoreManager.Instance.OnFoodScoreChanged += UpdateFoodScoreUI;
            TrapManager.Instance.LiveChanged += UpdateLivesCountUI;
            TrapManager.Instance.OnGameOver += HandleGameOver;
            UpdateFoodScoreUI(ScoreManager.Instance.GetScore());
            UpdateLivesCountUI(TrapManager.Instance.GetLives());
        }
    }


    private void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<CharacterMovement>();
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                UpdateHealthUI(playerHealth.GetCurrentHealth(), playerHealth.maxHealth);
            }
        }
    }

    public void HandleCurrentLevelFailure()
    {
        TrapManager.Instance.MinusLive();
        Debug.Log(TrapManager.Instance.GetLives() <= 0);
        if (TrapManager.Instance.GetLives() <= 0)
        {
            HandleGameOver();
            return;
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.ResetLifeSpan(); // Reset health to max
                UpdateHealthUI(playerHealth.GetCurrentHealth(), playerHealth.maxHealth); //  update this slider
            }

            if (CheckpointManager.Instance != null && CheckpointManager.Instance.HasCheckpoint())
            {
                player.transform.position = CheckpointManager.Instance.GetCheckpoint();
                Debug.Log("Player respawned at checkpoint.");
            }
            else
            {
                Debug.Log("No checkpoint found. Reloading scene...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }

       

        ScoreManager.Instance.SubtractScore();
    }

     private void HandleGameOver()
    {
        Debug.Log("Game Over! Loading end scene...");
        //totalTimePlayed = timePlayed;
        //ResetJumpBoost();
        //ResetSpeedBoost();
        //UpdateTimeUI(totalTimePlayed);
        Time.timeScale = 0f;
        //ResetTime();
        SceneManager.LoadScene("EndScene");
    }

    private void CheckLevelCompletionConditions()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");

        if (enemies.Length == 0 && orbs.Length >= 2)
        {
            LoadNextLevel();
        }
    }

     private void UpdateFoodScoreUI(int newScore)
    {
        foodText.text = "Food: " + newScore;
    }

    private void UpdateLivesCountUI(int lives)
    {
        livesText.text = "" + lives;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void ResetAllUI()
    {
        foodText.text = "Food: 0";
        livesText.text = "Lives: 3";
        //ResetTime();
    }
    


    // public void UpdatePickupText(string message)
    // {
    //     pickupText.text = message;
    //     isPickupTextActive = true;
    //     pickupTimer = pickupDuration;
    // }

    private void Update()
    {
        if (isPlaying)
        {
            //timePlayed += Time.deltaTime;
            //totalTimePlayed = timePlayed;
            //UpdateTimeUI(timePlayed);
            CheckLevelCompletionConditions();
        }

        if (playerMovement == null)
        {
            FindPlayer();
        }

        // if (playerMovement.canDoubleJump && jumpTimer < jumpCooldown)
        // {
        //     jumpTimer += Time.deltaTime;
        //     UpdateJumpBoosterTime("Jump: " + (int)jumpTimer + "s");
        // }
        // else
        // {
        //     ResetJumpBoost();
        // }

        // if (canSpeedUp && speedTimer < speedCooldown)
        // {
        //     speedTimer += Time.deltaTime;
        //     UpdateSpeedBoosterTime("Speed: " + (int)speedTimer + "s");
        // }
        // else
        // {
        //     ResetSpeedBoost();
        // }

        // if (isPickupTextActive)
        // {
        //     pickupTimer -= Time.deltaTime;
        //     if (pickupTimer < 0)
        //     {
        //         isPickupTextActive = false;
        //         pickupText.text = "";
        //     }
        // }
    }
}
