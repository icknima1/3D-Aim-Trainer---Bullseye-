using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamemodesPanel;
    public GameObject settingsPanel;
    public GameObject statsPanel;
    public GameObject difficultyPanel;

// Basic functions for navigating main menu, starting game modes, and quitting the game, called by UI buttons.
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenGameModes()
    {
        mainMenuPanel.SetActive(false);
        gamemodesPanel.SetActive(true);
    }
    public void CloseGameModes()
    {
        gamemodesPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void StartClassicMode()
    {
        Debug.Log("Starting Classic Mode...");
        SceneManager.LoadScene("ClassicMode");
    }

    public void StartTrackingMode()
    {
        Debug.Log("Starting Tracking Mode...");
        SceneManager.LoadScene("TrackingMode");
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OpenStats()
    {
        mainMenuPanel.SetActive(false);
        statsPanel.SetActive(true);
    }
    public void CloseStats()
    {
        statsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OpenDifficulty()
    {
        settingsPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }
    public void CloseDifficulty()
    {
        difficultyPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
