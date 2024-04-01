using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CamBase : MonoBehaviour
{
    private float sensX;
    private float sensY;

    public float mouseSens;
    public Transform orientation;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private float zRotation = 0f;
    private float horizontalInput;

    public float smoothness = 5f; // Adjust the smoothness factor to control the smoothing amount

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        sensX = mouseSens;
        sensY = mouseSens;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // Get Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        // Update rotation
        yRotation += mouseX;
        xRotation -= mouseY;

        // Clamp vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Smooth the rotations
        Quaternion targetOrientation = Quaternion.Euler(xRotation, yRotation, zRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientation, smoothness * Time.deltaTime);

        // Rotate Orientation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}