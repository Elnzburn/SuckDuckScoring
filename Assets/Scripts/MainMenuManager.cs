using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("MenuManager Loaded!");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit Complete!");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Scene is Loaded");
    }
}
