using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform target; // The character to follow
    public float distance = 5f;
    public float height = 2f;
    public float sensitivity = 5f;
    public float rotationSpeed = 5f;
    
    private Vector3 offset;
    private float currentRotationAngle;
    private float currentHeight;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        HandleMouseInput();
        HandleCameraPosition();
    }

    void HandleMouseInput()
    {
        horizontalInput = Input.GetAxis("Mouse X") * sensitivity;
        verticalInput = Input.GetAxis("Mouse Y") * sensitivity;
    }

    void HandleCameraPosition()
    {
        Vector3 targetUp = -Physics.gravity.normalized;
        var finaloffset = target.TransformDirection(offset);
        Vector3 desiredPosition = target.position + target.rotation * finaloffset;

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - desiredPosition, targetUp);
        currentRotationAngle = Mathf.LerpAngle(transform.eulerAngles.y, desiredRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        currentHeight = Mathf.Lerp(transform.position.y, target.position.y + height, rotationSpeed * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        transform.position = target.position - (currentRotation * Vector3.forward * distance) + (targetUp * height);
        
        transform.LookAt(target, targetUp);
    }
}
