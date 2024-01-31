using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour
{
    public void playEgg()
    {
        Debug.Log("Playing Easter Egg");
        SceneManager.LoadScene("Easter Egg");
    }
    
    public void returnToGame()
    {
        Debug.Log("Return To Menu");
        SceneManager.LoadScene("Main Menu");
    }
}
