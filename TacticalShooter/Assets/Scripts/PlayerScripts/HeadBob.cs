using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float rotationNoiseFrequency = 1.0f;
    public float rotationNoiseMagnitude = 1.0f;
    public float midpoint = 2.0f;

    private float timer = 0.0f;

    void Update()
    {
        // Calculate head bobbing motion
        float wavesliceX = Mathf.Sin(timer);
        float wavesliceY = Mathf.Sin(timer * 2); // You can adjust the multiplier to change the frequency of bobbing

        timer = timer + bobbingSpeed;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }

        // Calculate smooth head rotation noise using Perlin noise
        float rotationNoiseX = Mathf.PerlinNoise(Time.time * rotationNoiseFrequency, 0) * 2 - 1;
        float rotationNoiseY = Mathf.PerlinNoise(0, Time.time * rotationNoiseFrequency) * 2 - 1;

        // Apply bobbing motion and rotation noise to the camera's position
        float translateChangeX = wavesliceX * bobbingAmount + rotationNoiseX * rotationNoiseMagnitude;
        float translateChangeY = wavesliceY * bobbingAmount + rotationNoiseY * rotationNoiseMagnitude;

        transform.localPosition = new Vector3(midpoint + translateChangeX, midpoint + translateChangeY, transform.localPosition.z);
    }
}
