using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas Canvas;
    public bool isGameStopped;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        PauseController();
    }

    private void PauseController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name != "GameScene") { return; }
            if(Canvas.enabled)
            {
                Canvas.enabled = false;
                isGameStopped = false;
                Time.timeScale = 1.0f;
            }
            else
            {
                Canvas.enabled = true;
                isGameStopped = true;
                Time.timeScale = 0f;
            }
        }
    }
    public void PlayGameButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGameButton()
    {
        Canvas.enabled = false;
        isGameStopped = false;
        Time.timeScale = 1.0f;
    }
    public void PauseGameButton()
    {
        Canvas.enabled = true;
        isGameStopped = true;
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
