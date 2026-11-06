using UnityEngine;
using TMPro;
public class TimerManager : MonoBehaviour
{
   public float timeRemaining = 60f;
   public GameObject pauseMenu;
   private bool isPaused = false;
   public TMP_Text timerText;
   public TMP_Text finalScoreText;
   public TMP_Text finalAccuracyText;
   public GameObject gameOverPanel;
   public PlayerController lookScript; // Reference to the look script to disable it on game over
   public ScoreManager scoreManager;
   private bool isGameOver = false;
   private bool isGameStarted = false;
   public bool GameStarted => isGameStarted;
    // void Start()
    // {
    //     int difficulty = PlayerPrefs.GetInt("Difficulty_Classic", 1);

    //     timeRemaining = difficulty switch
    //     {
    //         0 => 60f,
    //         1 => 45f,
    //         2 => 30f,
    //         _ => 45f
    //     };
    // }
    void Update()
    {
        if (isGameOver) return;
        if (!isGameStarted)
        {
            timerText.text = "Click to start";
            if (Input.GetMouseButtonDown(0))
            {
                isGameStarted = true;
            }
            else
            {
                return; // don't run timer/pause logic yet
            }
        }

         if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "Time: 0";
            isGameOver = true;
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lookScript.enabled = false;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookScript.enabled = true;
    }

    public void QuitRound()
    {
        Time.timeScale = 1f;
        scoreManager.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        int finalScore = ScoreManager.score;
        finalScoreText.text = "Score: " + finalScore.ToString();
        float finalAccuracy = ScoreManager.accuracy;
        finalAccuracyText.text = "Accuracy: " + finalAccuracy.ToString("F1") + "%";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lookScript.enabled = false;
        scoreManager.UpdateStats();
        scoreManager.ResetScore();
    }

}
