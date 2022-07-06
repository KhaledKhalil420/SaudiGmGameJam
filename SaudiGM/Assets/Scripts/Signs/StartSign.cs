using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSign : MonoBehaviour
{
    public MainMenuCam cam;
    public Animator animator;
    private void OnMouseUpAsButton()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
        animator.SetTrigger("GameStarted");
        cam.Zoom();
    }
}
