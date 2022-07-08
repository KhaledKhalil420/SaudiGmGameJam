using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform ShootingPos;
    [SerializeField] GameObject Bullet;
    public void Shoot()
    {
        Instantiate(Bullet, ShootingPos.position, ShootingPos.rotation);    
        FindObjectOfType<AudioManager>().Play("ArrowShootingSound");
    }
}
