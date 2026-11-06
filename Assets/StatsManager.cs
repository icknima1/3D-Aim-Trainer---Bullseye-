using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI gamesPlayedText;
    [SerializeField] TMPro.TextMeshProUGUI classicHighScoreText;
    [SerializeField] TMPro.TextMeshProUGUI trackingHighScoreText;
    [SerializeField] TMPro.TextMeshProUGUI bestAccuracyText;
    [SerializeField] TMPro.TextMeshProUGUI classicAveAccuracyText;
    [SerializeField] TMPro.TextMeshProUGUI trackingAveAccuracyText;
    [SerializeField] TMPro.TextMeshProUGUI classicGamesPlayedText;
    [SerializeField] TMPro.TextMeshProUGUI trackingGamesPlayedText;

    void Start()
    {
        // Load stats from PlayerPrefs and display them
        int trackingGamesPlayed = PlayerPrefs.GetInt("TrackingGamesPlayed", 0);
        int classicGamesPlayed = PlayerPrefs.GetInt("ClassicGamesPlayed", 0);
        int classicHighScore = PlayerPrefs.GetInt("ClassicHighScore", 0);
        int trackingHighScore = PlayerPrefs.GetInt("TrackingHighScore", 0);
        float bestAccuracy = PlayerPrefs.GetFloat("BestAccuracy", 0f);
        float totalClassicAccuracy = PlayerPrefs.GetFloat("TotalClassicAccuracy", 0f);
        float totalTrackingAccuracy = PlayerPrefs.GetFloat("TotalTrackingAccuracy", 0f);
        float classicAverageAccuracy = (classicGamesPlayed > 0) ? totalClassicAccuracy / classicGamesPlayed : 0f;
        float trackingAverageAccuracy = (trackingGamesPlayed > 0) ? totalTrackingAccuracy / trackingGamesPlayed : 0f;

        // Update UI text with loaded stats
        classicGamesPlayedText.text = "Games Played: " + (classicGamesPlayed).ToString();
        trackingGamesPlayedText.text = "Games Played: " + (trackingGamesPlayed).ToString();
        classicHighScoreText.text = "High Score: " + classicHighScore.ToString();
        trackingHighScoreText.text = "High Score: " + trackingHighScore.ToString();
        bestAccuracyText.text = "Best Accuracy: " + bestAccuracy.ToString("F1") + "%";
        classicAveAccuracyText.text = "Average Accuracy: " + classicAverageAccuracy.ToString("F1") + "%";
        trackingAveAccuracyText.text = "Average Accuracy: " + trackingAverageAccuracy.ToString("F1") + "%"; 
    }

    public void ResetStats()
    {
        // Clear stats from PlayerPrefs
        PlayerPrefs.DeleteKey("GamesPlayed");
        PlayerPrefs.DeleteKey("ClassicHighScore");
        PlayerPrefs.DeleteKey("TrackingHighScore");
        PlayerPrefs.DeleteKey("BestAccuracy");
        PlayerPrefs.DeleteKey("TotalClassicAccuracy");
        PlayerPrefs.DeleteKey("TotalTrackingAccuracy");
        PlayerPrefs.DeleteKey("ClassicGamesPlayed");
        PlayerPrefs.DeleteKey("TrackingGamesPlayed");

        // Reset UI text to default values
        gamesPlayedText.text = "Games Played: 0";
        classicHighScoreText.text = "High Score: 0";
        trackingHighScoreText.text = "High Score: 0";
        bestAccuracyText.text = "Best Accuracy: 0.0%";
        classicAveAccuracyText.text = "Average Accuracy: 0.0%";
        trackingAveAccuracyText.text = "Average Accuracy: 0.0%";
        classicGamesPlayedText.text = "Games Played: 0";
        trackingGamesPlayedText.text = "Games Played: 0";

        PlayerPrefs.Save();
    }
  
}
