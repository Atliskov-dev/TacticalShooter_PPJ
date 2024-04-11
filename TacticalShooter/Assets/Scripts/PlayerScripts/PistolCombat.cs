using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PistolCombat : MonoBehaviour
{
    public Animator anim;
    public Animator aimAnim;


    public HeadBob bobbing;
    public Player_Movement movement;

    //CamShake
    public Transform mainCamera;

    //PostProcessing
    public Volume volume;
    float shootingTime = 0.15f;
    public bool isShooting;
    public float blurFloat;
    public float vignetteFloat;
    public float postExposureFloat;
    public float saturationFloat;
    public Light muzzleFlashLight;
    public float muzzleFlashLightAmount;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& movement.running == false && isShooting == false) 
        {
            isShooting = true;
            anim.Play("Base Layer.metarig_Fire", 0, 0);
            mainCamera.Rotate(Vector3.forward, 1500 * Time.deltaTime);
            mainCamera.Rotate(Vector3.right * Random.Range(1f, -1f), 200 * Time.deltaTime);
            muzzleFlashLight.intensity = muzzleFlashLightAmount;
        }
        if (isShooting) 
        {
            shootingTime -= Time.deltaTime;
            if (shootingTime <= 0) 
            {
                shootingTime = 0.15f;
                isShooting = false;
            }

            blurFloat = 12f;
            vignetteFloat = 0.35f;
            postExposureFloat = 1.25f;
            saturationFloat = 60f;
        }
        else 
        {
            blurFloat = Mathf.Lerp(blurFloat, 1, Time.deltaTime * 1f);
            vignetteFloat = Mathf.Lerp(vignetteFloat, 0, Time.deltaTime * 0.5f);
            saturationFloat = Mathf.Lerp(saturationFloat, 0, Time.deltaTime * 1f);
            postExposureFloat = Mathf.Lerp(postExposureFloat, 0, Time.deltaTime * 0.25f);
            muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, 0.25f);

        }

        
        volume.profile.TryGet(out DepthOfField depthOfField);
        volume.profile.TryGet(out Vignette vignette);
        volume.profile.TryGet(out ColorAdjustments colorAdjustments);
        depthOfField.focalLength.value = blurFloat;
        vignette.intensity.value = vignetteFloat;
        colorAdjustments.postExposure.value = postExposureFloat;
        colorAdjustments.saturation.value = saturationFloat;





        if (Input.GetKeyDown(KeyCode.R) && movement.running == false) 
        {
            anim.Play("Base Layer.metarig_Reload", 0, 0);
        }



        if (Input.GetKey(KeyCode.Mouse1) && movement.running == false) 
        {
            aimAnim.SetBool("Aim", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && movement.running == false)
        {
            aimAnim.SetBool("Aim", false);
            
        }


        if (movement.running == true) 
        {
            anim.SetBool("Running", true);
            aimAnim.SetBool("Running", true);
        }
        else 
        {
            anim.SetBool("Running", false);
            aimAnim.SetBool("Running", false);
        }
    }
}
