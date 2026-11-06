using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Color[] targetColours;
    [SerializeField] private Material targetMaterial;
    public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
        FindAnyObjectByType<ScoreManager>().UpdateScore(1);  // Increment score by 1 when hit
    }

    public void SetColour(Color colour)
    {
         Debug.Log($"[TargetColour] SetColour CALLED on {name} with {colour}");
        if (targetMaterial == null)
        {
            Debug.LogWarning("Target material not assigned.");
            return;
        }
        var m = targetMaterial;
        if (m.HasProperty("_BaseColor"))
        {
            m.SetColor("_BaseColor", colour);
            Debug.Log($"[TargetColour] Set _BaseColor to {colour} for material {m.name}");
        }
        else if (m.HasProperty("_Color"))
        {
            m.SetColor("_Color", colour);
            Debug.Log($"[TargetColour] Set _Color to {colour} for material {m.name}");
        }
        else
        {
            Debug.LogWarning("Material does not have _BaseColor or _Color property to set target colour.");
        }
    }

    public void ApplyTargetColour(int index) // This method will be called from the SettingsManager when the target colour is changed
    {
        if (targetColours == null || targetColours.Length == 0) // Check if target colours are assigned
        {
            Debug.LogWarning("Target colours not assigned.");
            return;
        }

        index = Mathf.Clamp(index, 0, targetColours.Length - 1); // Ensure index is within bounds
        Color newColour = targetColours[index]; // Get the new colour from the array based on the index

        Debug.Log($"[TargetColour] Using colour {newColour} at clamped index {index}");

        foreach (Target target in FindObjectsByType<Target>(FindObjectsSortMode.None)) // Apply the new colour to all targets in the scene
        {
            target.SetColour(newColour);
        }
    }
}
