using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void LoadConstanta()
    {
        SceneManager.LoadScene("Constanta");
    }
    
    public void LoadBucuresti()
    {
        SceneManager.LoadScene("Bucuresti");
    }
    
    public void LoadBrasov()
    {
        SceneManager.LoadScene("Brasov");
    }
    
    public void LoadPloiesti()
    {
        SceneManager.LoadScene("Ploiesti");
    }
    
    public void LoadCluj()
    {
        SceneManager.LoadScene("Cluj");
    }
    
    public void LoadIasi()
    {
        SceneManager.LoadScene("Iasi");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(currentScene.ToString());
    }

    public void QuitMenu()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
