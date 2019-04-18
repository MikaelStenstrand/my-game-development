using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour	{

    [SerializeField] Canvas menuCanvas;
    [SerializeField] Animator sceneFaderAnimator;

    public void PlayGame() {
        Debug.Log("fading out");
        this.FadeOutScene();

        Invoke("LoadNextScene", 1.0f);
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

    void FadeOutScene() {
        sceneFaderAnimator.SetTrigger("SceneFadeOut");
    }
    void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
