using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioManager audioManager;
    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Create a ray from the center of the screen (crosshair position)
        if (Physics.Raycast(ray, out RaycastHit hitInfo)) // Perform a raycast and check if it hits any collider in the scene
        {
            Target target = hitInfo.collider.gameObject.GetComponent<Target>(); // Try to get the Target component from the hit object
            bool hitTarget = target != null; // Check if the hit object has a Target component (i.e., if it's a target)

            FindFirstObjectByType<ScoreManager>().RegisterShot(hitTarget); // Register the shot in the ScoreManager

            if (hitTarget)
            {
                target.Hit();
                audioManager.PlayHitSound(); // Play hit sound if a target was hit
            }
            else
            {
                audioManager.PlayClickSound(); // Play click sound for a missed shot
            }
        }
        else
        {
            FindFirstObjectByType<ScoreManager>().RegisterShot(false); // Register a missed shot in the ScoreManager if the raycast did not hit any target
            audioManager.PlayClickSound(); // Play click sound for a missed shot
        }
    }
}
}
