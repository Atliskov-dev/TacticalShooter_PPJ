using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCombat : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            anim.Play("Base Layer.metarig_Fire", 0, 0);
        }
    }
}
