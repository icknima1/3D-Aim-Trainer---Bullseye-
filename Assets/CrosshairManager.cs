using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] crosshairTextures;
    [SerializeField] private UnityEngine.UI.RawImage crosshairImage;
    [SerializeField] private Color[] crosshairColours;
    [SerializeField] private Vector2 crosshairSizeRange = new(10f, 100f);
    void Start()
    {
        // Load crosshair settings from PlayerPrefs and apply them
        int crosshairIndex = PlayerPrefs.GetInt("Crosshair", 0);
        int crosshairColourIndex = PlayerPrefs.GetInt("CrosshairColour", 0);
        float crosshairSize = PlayerPrefs.GetFloat("CrosshairSize", 50f);
        ApplyCrosshairImage(crosshairIndex);
        ApplyCrosshairColour(crosshairColourIndex);
        ApplyCrosshairSize(crosshairSize);
    }

    public void ApplyCrosshairImage(int index)
    {
        if (crosshairTextures == null || crosshairTextures.Length == 0) // Check if crosshair textures are assigned
        {
            Debug.LogWarning("Crosshair textures not assigned.");
            return;
        }
        if (crosshairImage == null) // Check if crosshair image component is assigned
        {
            Debug.LogWarning("Crosshair image component not assigned.");
            return;
        }
        else
        {
            index = Mathf.Clamp(index, 0, crosshairTextures.Length - 1); // Ensure index is within bounds
            crosshairImage.texture = crosshairTextures[index];
        }
    }

    public void ApplyCrosshairColour(int index)
    {
        if (crosshairColours == null || crosshairColours.Length == 0)
        {
            Debug.LogWarning("Crosshair colours not assigned.");
            return;
        }
        if (crosshairImage == null)
        {
            Debug.LogWarning("Crosshair image component not assigned.");
            return;
        }
        else
        {
            index = Mathf.Clamp(index, 0, crosshairColours.Length - 1); // Ensure index is within bounds
            crosshairImage.color = crosshairColours[index]; // Set the color of the crosshair image to the selected colour
        }
    }

    public void ApplyCrosshairSize(float size)
    {
        if (crosshairImage == null)
        {
            Debug.LogWarning("Crosshair image component not assigned.");
            return;
        }
        size = Mathf.Clamp(size, crosshairSizeRange.x, crosshairSizeRange.y);
        crosshairImage.rectTransform.sizeDelta = new Vector2(size, size); // Set both width and height to the same value for a square crosshair
    }        

}