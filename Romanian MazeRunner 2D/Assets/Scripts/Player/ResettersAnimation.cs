using UnityEngine;
using UnityEngine.SceneManagement;

public class ResettersAnimation : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetHurtAnimation()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.isHurt = false;
    }
}