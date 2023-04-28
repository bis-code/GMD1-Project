using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {

        public GameObject pauseCanvas;
        private bool isPaused = false;


        private void Start()
        {
            pauseCanvas.gameObject.SetActive(false);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                pauseCanvas.gameObject.SetActive(true);
            }
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

        public void QuitMenu()
        {
            pauseCanvas.gameObject.SetActive(false);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
