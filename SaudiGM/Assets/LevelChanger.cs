using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator animator;
    public string startingScene;
    // Start is called before the first frame update
    public void FadeOut(){
        animator.SetTrigger("Fadeout");
        
    }
    public void StartGame(){
        SceneManager.LoadScene(startingScene, LoadSceneMode.Single);
    }
}
