using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool LoadNextLevel, Death;
    public Animator Anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && LoadNextLevel)
        StartCoroutine(FadeIn());
        if(other.gameObject.CompareTag("Player") && Death)
        FindObjectOfType<sceneManager>().LoadRandomDeathRoom();
    }
    IEnumerator FadeIn()
    {
        Anim.SetTrigger("FadeIn");
        FindObjectOfType<Movement>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<sceneManager>().LoadNextLevel();
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("FadeSound");
    }
}
