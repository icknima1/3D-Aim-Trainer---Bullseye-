using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;
    [SerializeField] new BoxCollider collider;
    void Awake()
    {
        Instance = this;
    }
    
    public Vector3 GetRandomPosition()
    {
        // Calculate the bounds of the box collider to determine the area within which targets can spawn
        Vector3 center = collider.center + transform.position;

        float minX = center.x - collider.size.x / 2f;
        float maxX = center.x + collider.size.x / 2f;

        float minY = center.y - collider.size.y / 2f;
        float maxY = center.y + collider.size.y / 2f;

        float minZ = center.z - collider.size.z / 2f;
        float maxZ = center.z + collider.size.z / 2f;

        float randomX = Random.Range(minX, maxX); // Generate a random X position within the bounds
        float randomY = Random.Range(minY, maxY); // Generate a random Y position within the bounds
        float randomZ = Random.Range(minZ, maxZ); // Generate a random Z position within the bounds

        Vector3 randomPosition = new(randomX, randomY, randomZ);
        
        return randomPosition;
    }
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty_Classic", 1);

        Vector3 baseSize = new(25, 15, 0.5f);

        float multiplier = difficulty switch
        {
            0 => 0.75f,   // Easy (smaller collider)
            1 => 0.8f,     // Medium
            2 => 1f,  // Hard (larger collider)
            _ => 1f
        };

        collider.size = new Vector3(
        baseSize.x * multiplier,
        baseSize.y * multiplier,
        baseSize.z   // unchanged
        );
    }
}