using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement movement;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(movement.up)
        {
            anim.SetInteger("Vertical", 1);
            anim.SetInteger("Horizontal", 0);
        }
        else if (movement.down)
        {
            anim.SetInteger("Vertical", -1);
            anim.SetInteger("Horizontal", 0);
        }
        else if (movement.right)
        {
            anim.SetInteger("Horizontal", 1);
            anim.SetInteger("Vertical", 0);
        }
        else if(movement.left)
        {
            anim.SetInteger("Horizontal", -1);
            anim.SetInteger("Vertical", 0);
        }
        else
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
        }
    }
}
