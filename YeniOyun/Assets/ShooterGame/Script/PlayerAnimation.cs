using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public static void Throw()
    {
        if (GameObject.FindGameObjectsWithTag("Bullet") != null && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.SetTrigger("Throw");
        }
        anim.SetTrigger("Stop");
    }
    public static void win()
    {

        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Throw")))
        {
            anim.SetTrigger("Win");

        }

    }
}
