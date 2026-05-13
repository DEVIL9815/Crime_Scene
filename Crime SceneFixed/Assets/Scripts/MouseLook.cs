using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 👇 THIS LINE IS THE KEY FIX
        xRotation -= mouseY;

        // 👇 LIMIT UP/DOWN LOOK
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 👇 APPLY UP/DOWN TO CAMERA ONLY
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 👇 APPLY LEFT/RIGHT TO PLAYER
        playerBody.Rotate(Vector3.up * mouseX);
    }
}