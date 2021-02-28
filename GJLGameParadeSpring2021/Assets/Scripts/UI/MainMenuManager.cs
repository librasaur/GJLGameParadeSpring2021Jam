using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        public void LoadScene(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OpenSidePanel(GameObject panel)
        {
            panel.SetActive(true);
        }

        public void CloseSidePanel(GameObject panel)
        {
            
        }
    }
}
