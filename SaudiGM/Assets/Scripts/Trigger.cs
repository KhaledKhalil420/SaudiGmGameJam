using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool LoadNextLevel, Death, DeadBody;
    public string CurrentLevelName;
    public Animator Anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && LoadNextLevel)
        StartCoroutine(FadeIn());
        if(other.gameObject.CompareTag("Player") && Death)
        StartCoroutine(FadeIn2());
        if(other.gameObject.CompareTag("Player") && DeadBody)
        StartCoroutine(FadeIn1());
    }
    IEnumerator FadeIn()
    {
        Anim.SetTrigger("FadeIn");
        FindObjectOfType<Movement>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<sceneManager>().LoadNextLevel();
    }
    IEnumerator FadeIn2()
    {
        Anim.SetTrigger("FadeIn");
        FindObjectOfType<Movement>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<sceneManager>().Restart();
    }
    IEnumerator FadeIn1()
    {
        Anim.SetTrigger("FadeIn");
        FindObjectOfType<Movement>().enabled = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(CurrentLevelName);
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("FadeSound");
    }
}
