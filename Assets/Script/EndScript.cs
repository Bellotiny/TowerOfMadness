using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private GameObject endPanel; 

    public void RestartGame()
    {
        //Time.timeScale = 1.0f;
        //isPaused = false;
        ScoreManager.Instance.ResetScore();
        TrapManager.Instance.RestoreLives();
        //InventoryMenuController.Instance.EnableInventoryAccess(); 
        //pauseMenuPanel.SetActive(false);
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScreen");
    }

     public void QuitGame()
    {
        Application.Quit();
    }
   
}
