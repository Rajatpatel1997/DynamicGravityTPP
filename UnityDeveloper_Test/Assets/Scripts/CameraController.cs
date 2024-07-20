using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;          // Reference to the player object
    public Vector3 offset;            // Offset from the player's position
    public float sensitivity = 2f;    // Mouse sensitivity
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    private Vector3 gravityDirection = Vector3.down;

    private void LateUpdate()
    {
        HandleCameraMovement();
    }

    public void UpdateCameraOrientation(Vector3 newGravityDirection)
    {
        gravityDirection = newGravityDirection;
        AdjustCameraPosition();
    }

    private void HandleCameraMovement()
    {
        // Mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Apply rotation to camera based on mouse input
        transform.RotateAround(player.position, Vector3.up, mouseX);
        transform.RotateAround(player.position, transform.right, -mouseY);

        // Adjust the camera position to the player position plus offset
        AdjustCameraPosition();
    }

    private void AdjustCameraPosition()
    {
        // Vector3 desiredPosition = player.position + offset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;
        
        // Adjust the camera's up direction based on the gravity direction
        // transform.up = -gravityDirection;
    }
}
