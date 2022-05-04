using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MAINMAINMenu");
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void NewGameScene()
    {
        SceneManager.LoadScene("NewGame");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("LoadGame");
    }

    public void QuitScene()
    {
        SceneManager.LoadScene("Quit");
    }

    public void GameSelectScene()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void MethodsScene()
    {
        SceneManager.LoadScene("Methods");

    }

    public void ParamentersScene()
    {
        SceneManager.LoadScene("Parameters");
    }

    public void ScopeScene()
    {
        SceneManager.LoadScene("Scope");
    }

    public void VariablesScene()
    {
        SceneManager.LoadScene("Variables");
    }

    public void HelpMainsScene()
    {
        SceneManager.LoadScene("Help");
    }

}