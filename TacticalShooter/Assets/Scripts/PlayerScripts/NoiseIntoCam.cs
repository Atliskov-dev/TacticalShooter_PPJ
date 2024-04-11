using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseIntoCam : MonoBehaviour
{
    // Intensity of the noise
    public float noiseIntensity;

    // Speed of the noise
    public float noiseSpeed;

    // Store initial rotation
    private Quaternion initialRotation;

    public float speedCurveIdle;
    public float intensityCurveIdle;

    public float speedCurveWalk;
    public float intensityCurveWalk;

    public float speedCurveRun;
    public float intensityCurveRun;

    public Player_Movement movement;

    public float timeIntense;
    public float timeSpeed;


    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Generate random noise values
        float noiseX = Mathf.PerlinNoise(Time.time * noiseSpeed, 0) * 2 - 1;
        float noiseY = Mathf.PerlinNoise(0, Time.time * noiseSpeed) * 2 - 1;

        // Apply noise to rotation
        Quaternion noiseRotation = Quaternion.Euler(noiseY * noiseIntensity, noiseX * noiseIntensity, 0f);

        // Apply noise to the initial rotation
        transform.rotation = initialRotation * noiseRotation;



        if (movement.running)
        {
            noiseIntensity = Mathf.Lerp(noiseIntensity, intensityCurveRun, timeIntense);
            //noiseSpeed = Mathf.Lerp(noiseSpeed, speedCurveRun, timeSpeed); 
        }
        else
        {
            if (movement.currentSpeed > 10)
            {
                noiseIntensity = Mathf.Lerp(noiseIntensity, intensityCurveWalk, timeIntense);
                //noiseSpeed = Mathf.Lerp(noiseSpeed, speedCurveWalk, timeSpeed);

            }

            if (movement.currentSpeed <= 10)
            {
                noiseIntensity = Mathf.Lerp(noiseIntensity, intensityCurveIdle, timeIntense);
                //noiseSpeed = Mathf.Lerp(noiseSpeed, speedCurveIdle, timeSpeed);
            }

        }
    }
}
