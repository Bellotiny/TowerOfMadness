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
        if (ScoreManager.Instance != null)
        {
            FindPlayer();
            ScoreManager.Instance.OnFoodScoreChanged += UpdateFoodScoreUI;
            TrapManager.Instance.LiveChanged += UpdateLivesCountUI;
            TrapManager.Instance.OnGameOver += HandleGameOver;
            UpdateFoodScoreUI(ScoreManager.Instance.GetScore());
            UpdateLivesCountUI(TrapManager.Instance.GetLives());
            
            ScoreManager.Instance.ResetOrbCount();
            CheckpointManager.Instance.ClearCheckpointOnFirstLoad();
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("PracEnemy");
        //GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
        int orbs = ScoreManager.Instance.GetOrbCount();
        Debug.Log("orbs: " + orbs + " & enemies: " + enemies.Length);

        if (enemies.Length == 0 && orbs >= 2)
        {
            LoadNextLevel();
        }
        else if (SceneManager.GetActiveScene().name == "Level0" && enemies.Length == 0 && orbs == 1)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            //save score then reset orb
            ScoreManager.Instance.SaveScore();
            ScoreManager.Instance.ResetOrbCount();
            CheckpointManager.Instance.ResetCheckpointState();//reset checkpount
            DialogueTrigger.ClearTriggeredFiles();

            //SceneManager.LoadScene(nextSceneIndex);
            StartCoroutine(LoadSceneAndResetPlayer(nextSceneIndex));//delay for a bit
        }
        else
        {
            Debug.Log("No more scenes available. Staying on current scene.");
        }
    }

    private IEnumerator LoadSceneAndResetPlayer(int sceneIndex)
    {
        yield return SceneManager.LoadSceneAsync(sceneIndex);

        // Wait one frame for scene load to finish
        yield return null;

        // Reset player health
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.ResetLifeSpan();
                UpdateHealthUI(playerHealth.GetCurrentHealth(), playerHealth.maxHealth);
            }
        }

        
        CheckpointManager.Instance.ClearCheckpointOnFirstLoad();
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
            // Debug.Log("CheckingCondition");
            CheckLevelCompletionConditions();
        }
        else
        {
            Debug.Log("Player not currently playing");
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
