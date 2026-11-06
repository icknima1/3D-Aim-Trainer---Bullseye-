using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    float scoreAcc = 0f;
    public static float accuracy = 0f;
    public static int shotsFired = 0;
    public static int targetsHit = 0;
    public float TimePlayed { get; private set; }
    public float TimeOnTarget { get; private set; }
    public TMP_Text accuracyText;
    public TMP_Text scoreText;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TrackingMode")
        {
            float dt = Time.deltaTime;
            TimePlayed += dt;

            accuracy = TimePlayed > 0f ? (TimeOnTarget / TimePlayed) * 100f : 0f;

            accuracyText.text = "Accuracy: " + accuracy.ToString("F1") + "%";
        }
        
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    public void RegisterShot(bool hit)
    {
        shotsFired++;
        if (hit)
        {
            targetsHit++;
        }
        accuracy = (shotsFired > 0) ? (float)targetsHit / shotsFired * 100f : 0f; // Calculate accuracy as a percentage
        accuracyText.text = "Accuracy: " + accuracy.ToString("F1") + "%";
        Debug.Log("Shot Registered: Hit = " + hit + ", Shots Fired = " + shotsFired + ", Targets Hit = " + targetsHit + ", Accuracy = " + accuracy.ToString("F1") + "%");
    }

    public void RegisterTrackingHit()
{
    float dt = Time.deltaTime;

    TimeOnTarget += dt;
    scoreAcc += 150f * dt;
    score = Mathf.FloorToInt(scoreAcc);

    scoreText.text = "Score: " + score;

    scoreText.text = "Score: " + score.ToString();
    Debug.Log("Tracking Hit Registered: TimeOnTarget = " + TimeOnTarget + ", Score = " + score);
}
    public void ResetScore()
    {
        score = 0;
        shotsFired = 0;
        targetsHit = 0;
        scoreText.text = "Score: 0";
        accuracyText.text = "Accuracy: 0.0%";
        
    }
    public void UpdateStats()
    {
        string scene = SceneManager.GetActiveScene().name;

        // Increment games played for the appropriate mode
        if (scene == "ClassicMode")
        {
            int classicGamesPlayed = PlayerPrefs.GetInt("ClassicGamesPlayed", 0);
            classicGamesPlayed++;
            PlayerPrefs.SetInt("ClassicGamesPlayed", classicGamesPlayed);
        }
        else if (scene == "TrackingMode")
        {
            int trackingGamesPlayed = PlayerPrefs.GetInt("TrackingGamesPlayed", 0);
            trackingGamesPlayed++;
            PlayerPrefs.SetInt("TrackingGamesPlayed", trackingGamesPlayed);
        }

        // Check and update high score if current score is greater
        int currentScore = score;
        float accuracy = ScoreManager.accuracy; // Get the accuracy from ScoreManager
        float bestAccuracy = PlayerPrefs.GetFloat("BestAccuracy", 0f);
        if (scene == "ClassicMode")
            {
                int classicHighScore = PlayerPrefs.GetInt("ClassicHighScore", 0);
                if (currentScore > classicHighScore)
                PlayerPrefs.SetInt("ClassicHighScore", currentScore);
            }
        else if (scene == "TrackingMode")
        {
            int trackingHighScore = PlayerPrefs.GetInt("TrackingHighScore", 0);
            if (currentScore > trackingHighScore)
            PlayerPrefs.SetInt("TrackingHighScore", currentScore);
            if (accuracy > bestAccuracy)
            {
                PlayerPrefs.SetFloat("BestAccuracy", accuracy);
            }
        }

        // Update total accuracy for average calculation
        if (scene == "ClassicMode")
        {
            float total = PlayerPrefs.GetFloat("TotalClassicAccuracy", 0f);
            total += accuracy;
            PlayerPrefs.SetFloat("TotalClassicAccuracy", total);
            Debug.Log("Total Classic Accuracy: " + total);
        }
        else if (scene == "TrackingMode")
        {
            float total = PlayerPrefs.GetFloat("TotalTrackingAccuracy", 0f);
            total += accuracy;
            PlayerPrefs.SetFloat("TotalTrackingAccuracy", total);
            Debug.Log("Total Tracking Accuracy: " + total);
        }
        PlayerPrefs.Save();
        Debug.Log("Stats Updated");
    }
}
