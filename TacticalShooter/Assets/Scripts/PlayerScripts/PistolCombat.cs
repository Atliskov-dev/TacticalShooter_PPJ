using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCombat : MonoBehaviour
{
    public Animator anim;
    public Animator aimAnim;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            anim.Play("Base Layer.metarig_Fire", 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            anim.SetTrigger("Reload");
        }



        if (Input.GetKey(KeyCode.Mouse1)) 
        {
            aimAnim.SetBool("Aim", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aimAnim.SetBool("Aim", false);
        }

    }
}
