using System.Collections;
using System.Collections.Generic;
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
    float shootingTime = 0.2f;
    public bool isShooting;
    public float blurFloat;
    public int blurInt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& movement.running == false) 
        {
            isShooting = true;
            anim.Play("Base Layer.metarig_Fire", 0, 0);
            mainCamera.Rotate(Vector3.forward, 1500 * Time.deltaTime);
            mainCamera.Rotate(Vector3.right, 200* Random.Range(1f,-1f) * Time.deltaTime);
        }
        if (isShooting) 
        {
            shootingTime -= Time.deltaTime;
            if (shootingTime <= 0) 
            {
                shootingTime = 0.2f;
                isShooting = false;
            }

            blurFloat = 12f;
        }
        else 
        {
            blurFloat = Mathf.Lerp(blurFloat, 1, Time.deltaTime * 1f);

        }

        blurInt = (int)blurFloat;
        volume.profile.TryGet(out DepthOfField depthOfField);
        depthOfField.focalLength.value = blurInt;






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
