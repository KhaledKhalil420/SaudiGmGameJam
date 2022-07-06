using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Damage"))
        {
            FindObjectOfType<sceneManager>().LoadRandomDeathRoom();
            GetComponent<Movement>().enabled = false;
            FindObjectOfType<CamLook>().enabled = false;
            transform.localScale = new(1, 0.5f, 1);
        }
    }
}
