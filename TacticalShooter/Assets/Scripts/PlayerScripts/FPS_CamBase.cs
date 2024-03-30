using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CamBase : MonoBehaviour
{

    private float sensX;
    private float sensY;

    public float mouseSens;

    public Transform orientation;

    float xRotation;
    float yRotation;
    public float zRotation;
    float horizontalInput;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //Get Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        sensY = mouseSens;
        sensX = mouseSens;

        // Rotate Cam and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        

    }

}