using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour
{
    public MainMenuCam cam;
    public Animator animator;
    private void OnMouseUpAsButton()
    {
        if (animator.GetBool("InfoIsOpen") == false)
            animator.SetBool("InfoIsOpen", true);
        else if (animator.GetBool("InfoIsOpen") == true)
            animator.SetBool("InfoIsOpen", false);
        cam.MoveLeft();
    }
}
