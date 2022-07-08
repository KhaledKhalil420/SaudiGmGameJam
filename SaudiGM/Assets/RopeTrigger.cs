using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTrigger : MonoBehaviour
{
    public GameObject NearestShootingCannon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            NearestShootingCannon.GetComponent<Cannon>().Shoot();
        }
    }
}
