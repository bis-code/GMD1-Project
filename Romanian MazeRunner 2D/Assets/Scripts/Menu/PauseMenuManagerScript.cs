using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManagerScript : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pauseCanvas.gameObject.SetActive(true);
            isPaused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pauseCanvas.gameObject.SetActive(false);
            isPaused = false;
        }
    }
}
