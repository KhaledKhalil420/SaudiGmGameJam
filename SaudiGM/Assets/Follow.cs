using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public bool FollowPosition, FollowRotation;
    public Transform TargetPosition, TargetRotation;
    public Quaternion RotationOffset;
    public float Smoothness;

    private void Update()
    {
        if(FollowPosition)
        transform.position = TargetPosition.position;
        if(FollowRotation)
        {
           transform.rotation = Quaternion.Slerp(transform.localRotation, TargetRotation.rotation * RotationOffset, Smoothness * Time.deltaTime); 
        }
    }
}
