using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations_Avatars : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(transform.parent.tag == "Walking")
        {
            animator.SetBool("walking", true);
            animator.SetBool("talking", false);
            animator.SetBool("idle", false);
        }
        else if(transform.parent.tag == "Talking")
        {
            animator.SetBool("talking", true);
            animator.SetBool("idle", false);
            animator.SetBool("walking", false);
        }
        else if (transform.parent.tag == "Idle")
        {
            animator.SetBool("idle", true);
            animator.SetBool("walking", false);
            animator.SetBool("talking", false);
        }
    }
}
