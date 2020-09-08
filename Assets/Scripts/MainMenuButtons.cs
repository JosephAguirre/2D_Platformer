using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene(4);
    }

    public void Objective()
    {
        SceneManager.LoadScene(5);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}