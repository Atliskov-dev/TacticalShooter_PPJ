using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float trauma = 0;

    public float shakeMult = 0.5f;
    public float smoothTime = 0.33f;
    public float horizontalMult = 0.8f;
    public float verticalMult = 1.33f;

    public const float MAX_TRAUMA = 4f;

    float v;


    public void MakeTrauma(float trauma_multiplier)
    {
        trauma = trauma_multiplier;
    }

    void LateUpdate()
    {
        trauma = Mathf.SmoothDamp(trauma, 0, ref v, smoothTime, 10, Time.unscaledDeltaTime);

        float offsetX = trauma * shakeMult * Random.Range(-1f, 1f) * horizontalMult;
        float offsetY = trauma * shakeMult * Random.Range(-1f, 1f) * verticalMult;


        //transform.localPosition = new Vector3(offsetX, offsetY, 0);

        transform.localRotation = Quaternion.Euler(offsetX, offsetY, 0);
    }

}
