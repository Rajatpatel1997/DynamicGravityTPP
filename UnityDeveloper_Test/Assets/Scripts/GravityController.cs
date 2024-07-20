using UnityEngine;

public class GravityController : MonoBehaviour
{
    public GameObject hologram;
    // public PlayerMovement characterMovement; // Ensure this is correctly assigned
    public Player.HumanoidMovement characterMovement; // Ensure this is correctly assigned

    // public CameraController cameraController;

    private Vector3[] gravityDirections = {
        Vector3.down, Vector3.up, Vector3.left, Vector3.right, Vector3.forward, Vector3.back
    };
    private int currentGravityIndex = 0;

    private void Update()
    {
        HandleGravityInput();
        ShowHologram();
    }

    private void HandleGravityInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            currentGravityIndex = 4;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            currentGravityIndex = 5;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentGravityIndex = 2;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            currentGravityIndex = 3;
        else if (Input.GetKeyDown(KeyCode.LeftControl))
            currentGravityIndex = 1;
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            currentGravityIndex = 0;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 selectedGravity = gravityDirections[currentGravityIndex];
            Physics.gravity = selectedGravity * 9.81f;
            characterMovement.UpdateGravityDirection(selectedGravity);
            // cameraController.UpdateCameraOrientation(selectedGravity);
        }
    }

    private void ShowHologram()
    {
        Vector3 selectedDirection = gravityDirections[currentGravityIndex];
        hologram.SetActive(true);
        hologram.transform.up = -selectedDirection;
    }
}
