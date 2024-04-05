using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCombat : MonoBehaviour
{
    public Animator anim;
    public Animator aimAnim;

    //public CameraShake camShake;
    public HeadBob bobbing;

    public Player_Movement player_Movement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& player_Movement.running == false) 
        {
            anim.Play("Base Layer.metarig_Fire", 0, 0);
            //camShake.MakeTrauma(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.R) && player_Movement.running == false) 
        {
            anim.SetTrigger("Reload");
        }



        if (Input.GetKey(KeyCode.Mouse1) && player_Movement.running == false) 
        {
            aimAnim.SetBool("Aim", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && player_Movement.running == false)
        {
            aimAnim.SetBool("Aim", false);
            
        }


        if (player_Movement.running == true) 
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
