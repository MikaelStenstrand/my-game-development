using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour	{

    [SerializeField] Canvas menuCanvas;
     
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Continue() {
        menuCanvas.enabled = false;
    }

    public void ToggleInGameMenu() {
        menuCanvas.enabled = !menuCanvas.enabled;
    }
}
