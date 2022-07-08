using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool IsInDeathRealm;
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Damage") && !IsInDeathRealm)
        {
            FindObjectOfType<sceneManager>().LoadRandomDeathRoom();
            GetComponent<Movement>().enabled = false;
            FindObjectOfType<CamLook>().enabled = false;
            transform.localScale = new(1, 0.5f, 1);
        }
        if(other.collider.CompareTag("Damage") && IsInDeathRealm)
        {
            FindObjectOfType<sceneManager>().Restart();
            GetComponent<Movement>().enabled = false;
            FindObjectOfType<CamLook>().enabled = false;
            transform.localScale = new(1, 0.5f, 1);
        }
    }
}
