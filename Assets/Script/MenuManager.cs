using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject controlsMenuPanel;
    private bool isControlMenuActive = false;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isControlMenuActive)
        {
            MenuBack();
        }
    }

    public void Control()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainMenuPanel.SetActive(false);
        controlsMenuPanel.SetActive(true);
        isControlMenuActive = true;
    }

    public void MenuBack()
    {
        controlsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        isControlMenuActive = false;
    }

    public void QuitGame()
    {
        // If you're in the editor, this won't fully work,
        // but in a built application, this will quit the game.
        Application.Quit();
        // If you have a Main Menu scene, you might do:
        // SceneManager.LoadScene("MainMenu");
    }




}
