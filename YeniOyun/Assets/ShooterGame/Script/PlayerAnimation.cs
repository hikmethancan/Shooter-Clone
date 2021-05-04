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
         anim.SetTrigger("Throw");
    }
    public static void win()
    {
         anim.SetTrigger("Win");

    }
}
