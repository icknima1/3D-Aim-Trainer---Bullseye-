using UnityEngine;

public class TrackingTargetShooter : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float maxDistance = 1000f;
    TimerManager timerManager;
    void Awake()
    {
        timerManager = FindFirstObjectByType<TimerManager>(); // Get reference to TimerManager to check if the game has started before allowing shooting
    }

    void Update()
    {
        if (timerManager != null && !timerManager.GameStarted) return;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Create a ray from the center of the screen (crosshair position)

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {
            
            if (hitInfo.collider.TryGetComponent<TrackingTarget>(out var target)) // Check if the hit object has a TrackingTarget component
            {
                FindFirstObjectByType<ScoreManager>().RegisterTrackingHit(); // Register a hit in the ScoreManager for tracking mode
            }
        }
    }
}
