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
}
