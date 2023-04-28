using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Scene currentScene;
    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
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
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
