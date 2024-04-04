using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    public GameObject gameoverMenuUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
