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
    public float currentSpeed;
    Vector3 lastPosition = Vector3.zero;
    public TextMeshProUGUI speedText;
    int speedTextInt;



    public AnimationCurve walkSpeed;
    public AnimationCurve runSpeed;
    public bool running;
    public float walkTimer;
    public float runTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(Calculations());
    }

    void Update()
    {
        Move();
    }
        
        

    void Move() 
    {
        //Basic Movement
        if (controller.isGrounded)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        // Curve Implementation
        if (horizontalInput != 0 || verticalInput != 0) 
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                running = true;
                runTimer += Time.deltaTime;
            }
            walkTimer += Time.deltaTime;
        }
        else 
        {
            walkTimer = 0f;
            running = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
            runTimer = 0f;
        }
        if (running)
        {
            runTimer += Time.deltaTime;
            speed = runSpeed.Evaluate(runTimer);
        }
        else 
        {
            speed = walkSpeed.Evaluate(walkTimer);
        }
        





    }
    IEnumerator Calculations() 
    {
        //Speed Show
        while (true) 
        {
            currentSpeed = (transform.position - lastPosition).magnitude;
            lastPosition = transform.position;
            currentSpeed *= 1000f;
            speedTextInt = (int)currentSpeed;
            speedText.text = speedTextInt.ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
        
        
        
