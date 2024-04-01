using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Input Values")]
    public float speed = 6.0f;
    public float gravity = 20.0f;


    [Header("Base Movement")]
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    float horizontalInput;
    float verticalInput;

    public Transform orientation;


    [Header("Indicators")]
    private float currentSpeed;
    Vector3 lastPosition = Vector3.zero;
    public TextMeshProUGUI speedText;




    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }
    private void LateUpdate()
    {
        Calculations();
    }

    void Move() 
    {
        if (controller.isGrounded)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


    }
    void Calculations() 
    {
        currentSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        currentSpeed *= 10000f;
        speedText.text = currentSpeed.ToString();
    }
}
