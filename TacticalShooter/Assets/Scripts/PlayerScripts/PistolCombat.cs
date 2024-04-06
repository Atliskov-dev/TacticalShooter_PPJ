using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCombat : MonoBehaviour
{
    public Animator anim;
    public Animator aimAnim;

    //public CameraShake camShake;
    public HeadBob bobbing;

    public Player_Movement movement;

    //CamShake
    public Transform mainCamera;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& movement.running == false) 
        {
            anim.Play("Base Layer.metarig_Fire", 0, 0);
            //camShake.MakeTrauma(0.1f);
            
            mainCamera.Rotate(Vector3.forward, 1500 * Time.deltaTime);
            mainCamera.Rotate(Vector3.right, 200* Random.Range(1f,-1f) * Time.deltaTime);
        }
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
