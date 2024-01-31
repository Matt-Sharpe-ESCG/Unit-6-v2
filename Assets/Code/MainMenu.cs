using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        Debug.Log("Playing Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void easterEgg()
    {
        Debug.Log("Easter Egg Triggered");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
