using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]GameObject ArrowEffect;
    [SerializeField]float Speed;
    Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.velocity = transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider)
        {
            Instantiate(ArrowEffect, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
