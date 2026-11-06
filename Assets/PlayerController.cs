using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private Transform cameraHolder;
     public float mouseSensitivity = 1f;
    float verticalLookRotation;
   void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
    }
   void Update()
   {
        transform.Rotate(Input.GetAxisRaw("Mouse X") * mouseSensitivity * Vector3.up); // Rotate the player horizontally based on mouse X input
        verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity; // Rotate the camera vertically based on mouse Y input
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); // Clamp the vertical rotation to prevent flipping
        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0); // Apply the vertical rotation to the camera holder
   }
}
 