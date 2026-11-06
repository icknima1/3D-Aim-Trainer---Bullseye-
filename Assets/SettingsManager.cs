using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider, sensitivitySlider, crosshairSizeSlider;
    [SerializeField] TMPro.TMP_Dropdown crosshairColourDropdown, crosshairDropdown, targetColourDropdown;
    [SerializeField] Button resetStatsButton;
    [SerializeField] Toggle[] classicToggles;  // [0]=Easy [1]=Medium [2]=Hard
    [SerializeField] Toggle[] trackingToggles;
    [SerializeField] TMPro.TMP_Text ClassicDifficultyText, TrackingDifficultyText; 
    private const string ClassicKey  = "Difficulty_Classic";
    private const string TrackingKey = "Difficulty_Tracking";
    [SerializeField] private CrosshairManager crosshairManager;
    [SerializeField] private Target targetScript;
    [SerializeField] private AudioManager audioManager;
    private bool difficultyWired = false; // flag to prevent multiple listener wiring

    void Start()
    {
        // Load settings from PlayerPrefs and apply them to the UI elements and game components
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Volume", 0.5f));
        sensitivitySlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Sensitivity", 1f));
        crosshairDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Crosshair", 0));
        crosshairSizeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("CrosshairSize", 50f));
        targetColourDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("TargetColour", 0));
        crosshairColourDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("CrosshairColour", 0));
        
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // Add listener for volume slider changes

        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged); // Listeners for the rest of the settings UI elements
        crosshairSizeSlider.onValueChanged.AddListener(OnCrosshairSizeChanged);
        crosshairColourDropdown.onValueChanged.AddListener(OnCrosshairColourChanged);
        crosshairDropdown.onValueChanged.AddListener(OnCrosshairChanged);
        targetColourDropdown.onValueChanged.AddListener(OnTargetColourChanged);
        resetStatsButton.onClick.AddListener(ResetStats);
    }

    private void OnEnable()
    {
        // Always restore UI state when this panel becomes active
        LoadDifficultyIntoToggles(classicToggles, ClassicKey);
        LoadDifficultyIntoToggles(trackingToggles, TrackingKey);

        // Also refresh the labels
        UpdateDifficultyText();

        // Wire listeners once only (so they don't stack)
        if (!difficultyWired)
        {
            AddDifficultyListeners(classicToggles, ClassicKey);
            AddDifficultyListeners(trackingToggles, TrackingKey);
            difficultyWired = true;
        }
    }
    private void AddDifficultyListeners(Toggle[] toggles, string key)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i; // capture
            toggles[i].onValueChanged.AddListener(isOn =>
        {
            Debug.Log("Value Changed");
            if (!isOn) return;
            SaveDifficulty(key, index);
        });
        }
    }
    private void SaveDifficulty(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();

        UpdateDifficultyText();

        Debug.Log($"[Difficulty] {key} set to {(value == 0 ? "Easy" : value == 1 ? "Medium" : "Hard")}");
    }

    private void UpdateDifficultyText()
    {
        int c = PlayerPrefs.GetInt(ClassicKey, 0);
        int t = PlayerPrefs.GetInt(TrackingKey, 0);

        ClassicDifficultyText.text  = $"Classic Difficulty: {(c == 0 ? "Easy" : c == 1 ? "Medium" : "Hard")}";
        TrackingDifficultyText.text = $"Tracking Difficulty: {(t == 0 ? "Easy" : t == 1 ? "Medium" : "Hard")}";
    }    
    private void LoadDifficultyIntoToggles(Toggle[] toggles, string key)
    {
        int diff = PlayerPrefs.GetInt(key, 0);

        for (int i = 0; i < toggles.Length; i++)
            toggles[i].SetIsOnWithoutNotify(i == diff); // sets state AND updates visuals
    }
    public void OnVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        audioManager.ApplyVolume(value);
        Debug.Log("Volume slider value: " + value);
    }
    void OnSensitivityChanged(float value)
    {
        PlayerPrefs.SetFloat("Sensitivity", value);
    }
    void OnCrosshairSizeChanged(float value)
    {
        PlayerPrefs.SetFloat("CrosshairSize", value);
        crosshairManager.ApplyCrosshairSize(value); // Apply the new crosshair size immediately when the slider value changes
    }
 void OnTargetColourChanged(int value)
    {
        PlayerPrefs.SetInt("TargetColour", value);
        targetScript.ApplyTargetColour(value); // Apply the new target colour immediately when the dropdown value changes
    }
    void OnCrosshairChanged(int value)
    {
        PlayerPrefs.SetInt("Crosshair", crosshairDropdown.value);
        crosshairManager.ApplyCrosshairImage(crosshairDropdown.value); // Apply the new crosshair image immediately when the dropdown value changes
    }
    void OnCrosshairColourChanged(int value)
    {
        PlayerPrefs.SetInt("CrosshairColour", value);
        crosshairManager.ApplyCrosshairColour(value);
    }
    void ResetStats()
    {
        // Clear stats from PlayerPrefs
        PlayerPrefs.DeleteKey("GamesPlayed");
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("BestAccuracy");
        PlayerPrefs.DeleteKey("TotalAccuracy");
        Debug.Log("Player stats have been reset.");
    }
}