using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip hitSound;
    [SerializeField] private AudioSource sfxSource; // one source for clicks/hits
    void Start()
    {
        PlayerPrefs.GetFloat("Volume", 1f); // Load saved volume or default to 1
        ApplyVolume(PlayerPrefs.GetFloat("Volume", 1f)); // Apply the loaded volume setting
    }
    public void ApplyVolume(float volume)
    {
        Debug.Log("Applying volume: " + volume); // Debug log to verify the function is called and the volume value
        AudioListener.volume = volume;
    }

    public void PlayClickSound() // Play click sound effect when changing settings in the menu
    {
        if (sfxSource != null && clickSound != null)
            sfxSource.PlayOneShot(clickSound);
    }

    public void PlayHitSound()
    {
        if (sfxSource != null && hitSound != null)
            sfxSource.PlayOneShot(hitSound);
    }
}
