using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static PauseMenuController Instance { get; private set; }
    [SerializeField] private GameObject pauseMenuPanel; 
    private bool isPaused = false;

    void Awake()
    {
         if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        if (pauseMenuPanel == null) return;
        
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuPanel == null) return;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void RestartGame()
    {
        //Time.timeScale = 1.0f;
        isPaused = false;
        ScoreManager.Instance.ResetScore();
        TrapManager.Instance.RestoreLives();
        //InventoryMenuController.Instance.EnableInventoryAccess(); 
        pauseMenuPanel.SetActive(false);
         Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScreen");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        //ScoreManager.Instance.SubtractScore();
        //TrapManager.Instance.RestoreLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
