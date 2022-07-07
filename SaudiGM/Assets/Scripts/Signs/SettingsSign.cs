using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSign : MonoBehaviour
{
    public MainMenuCam cam;
    public Animator animator;
    private void OnMouseUpAsButton()
    {
        if (animator.GetBool("SetIsOpen") == false)
            animator.SetBool("SetIsOpen", true);
        else if (animator.GetBool("SetIsOpen") == true)
            animator.SetBool("SetIsOpen", false);
        cam.MoveRight();
    }
}
