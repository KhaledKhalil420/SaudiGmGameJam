using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool LoadNextLevel, Death;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && LoadNextLevel)
        FindObjectOfType<sceneManager>().LoadNextLevel();
        if(other.gameObject.CompareTag("Player") && Death)
        FindObjectOfType<sceneManager>().LoadRandomDeathRoom();
    }
}
