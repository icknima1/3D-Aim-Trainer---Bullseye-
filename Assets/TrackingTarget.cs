using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrackingTarget : MonoBehaviour
{
    [SerializeField] BoxCollider boundsCollider;
    [SerializeField] SphereCollider targetCollider;
    private float baseColliderRadius;
    public float speed = 2f;
    public float turnSmooth = 1.5f;     // how gently it steers
    public float noiseScale = 0.4f;     // how fast direction drifts
    public float noiseStrength = 0.6f;  // 0 = straight lines
    TimerManager timerManager;
    private Rigidbody rb;
    private Vector3 dir;

    private float seedX, seedY, seedZ;

    void Awake()
    {
        timerManager = FindFirstObjectByType<TimerManager>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        // Initialize random seeds for Perlin noise to ensure each target has a unique movement pattern
        seedX = UnityEngine.Random.value * 1000f;
        seedY = UnityEngine.Random.value * 1000f;
        seedZ = UnityEngine.Random.value * 1000f;

        // Start with a random direction on the unit sphere for 3D movement
        dir = UnityEngine.Random.onUnitSphere.normalized;

        baseColliderRadius = targetCollider.radius;
        
    }

        private void Start()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty_Tracking", 0);
        ApplyTrackingDifficulty(difficulty);
    }
    private void ApplyTrackingDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 0: // Easy
                speed = 3f;
                targetCollider.radius = 1.2f * baseColliderRadius;
                noiseScale = 0.3f;
                noiseStrength = 0.4f;
                break;

            case 1: // Medium
                speed = 5f;
                targetCollider.radius = 1f * baseColliderRadius;
                noiseScale = 0.4f;
                noiseStrength = 0.6f;
                break;

            case 2: // Hard
                speed = 8f;
                targetCollider.radius = 0.8f * baseColliderRadius;
                noiseScale = 0.5f;
                noiseStrength = 0.8f;
                break;
        }
    }
    void FixedUpdate()
    {
        if (timerManager != null && !timerManager.GameStarted) return;
        float t = Time.time;

        Vector3 desired = new Vector3(
            Mathf.PerlinNoise(seedX, t * noiseScale) * 2f - 1f,
            Mathf.PerlinNoise(seedY, t * noiseScale) * 2f - 1f,
            Mathf.PerlinNoise(seedZ, t * noiseScale) * 2f - 1f
        ).normalized; // Randomly changing desired direction based on Perlin noise for smooth, natural movement

        dir = Vector3.Slerp(dir, desired, turnSmooth * Time.fixedDeltaTime * noiseStrength).normalized; // Smoothly steer towards the desired direction

        Vector3 next = rb.position + speed * Time.fixedDeltaTime * dir;

    Bounds b = boundsCollider.bounds;
    if (next.x <= b.min.x || next.x >= b.max.x)
    {
        dir.x *= -1f;
    }

// Y boundary
    if (next.y <= b.min.y || next.y >= b.max.y)
    {
        dir.y *= -1f;
    }

// Z boundary
    if (next.z <= b.min.z || next.z >= b.max.z)
    {
        dir.z *= -1f;
    }

// Recalculate movement after reflection
next = rb.position + speed * Time.fixedDeltaTime * dir;
        
    if (boundsCollider != null)
        {
            next.x = Mathf.Clamp(next.x, b.min.x, b.max.x);
            next.y = Mathf.Clamp(next.y, b.min.y, b.max.y);
            next.z = Mathf.Clamp(next.z, b.min.z, b.max.z);
        }

        rb.MovePosition(next); // Move the target to the next position based on its speed and direction
}
}
