using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void GoBackToStart()
    {
        SceneManager.LoadScene(0);
    }
}
