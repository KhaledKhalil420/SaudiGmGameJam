using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCam : MonoBehaviour
{
    public Animator animator;

    public void Zoom()
    {
        animator.SetTrigger("GameStarted");
    }
    public void MoveRight()
    {
        if (animator.GetBool("SetIsOpen") == false)
            animator.SetBool("SetIsOpen", true);
        else if (animator.GetBool("SetIsOpen") == true)
            animator.SetBool("SetIsOpen", false);
    }
    public void MoveLeft()
    {
        if (animator.GetBool("InfoIsOpen") == false)
            animator.SetBool("InfoIsOpen", true);
        else if (animator.GetBool("InfoIsOpen") == true)
            animator.SetBool("InfoIsOpen", false);
    }
}
