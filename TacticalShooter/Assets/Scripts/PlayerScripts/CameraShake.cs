using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.1f;
    public float shakeAmount = 0.1f;

    private float shakeTimer = 0f;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Shake the camera rotationally
            float shakeAngle = Random.Range(-1f, 1f) * shakeAmount;
            Quaternion shakeRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, shakeAngle);
            transform.localRotation = originalRotation * shakeRotation;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the camera rotation
            shakeTimer = 0f;
            
        }
    }

    public void StartShake(float duration)
    {
        shakeDuration = duration;
        shakeTimer = duration;
    }
}
