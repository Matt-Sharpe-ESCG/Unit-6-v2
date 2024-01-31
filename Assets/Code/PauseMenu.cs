using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject gameControlList;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        gameControlList.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Resuming");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameControlList.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log("Paused");
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
