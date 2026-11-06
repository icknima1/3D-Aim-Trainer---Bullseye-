using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure time scale is reset in case it was changed during the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene to restart the game
        FindAnyObjectByType<ScoreManager>().ResetScore(); // Reset the score when restarting the game
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        FindAnyObjectByType<ScoreManager>().ResetScore();
    }
}
