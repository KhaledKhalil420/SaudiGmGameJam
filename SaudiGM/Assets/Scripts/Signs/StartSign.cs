using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSign : MonoBehaviour
{
    public MenuSounds sound;
    public MainMenuCam cam;
    public Animator animator;
    private void OnMouseUpAsButton()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
        animator.SetTrigger("GameStarted");
        cam.Zoom();
        sound.Drag();
        sound.Punch();
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Tutorial Level");
    }
}
