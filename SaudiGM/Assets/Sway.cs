using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float SwaySpeed, Smooth;
    public Vector3 Offset;
    public Transform Player;
    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * SwaySpeed;
        float MouseY = Input.GetAxisRaw("Mouse Y") * SwaySpeed;

        Quaternion RotationX = Quaternion.AngleAxis(-MouseY, Vector3.right + Offset);
        Quaternion RotationY = Quaternion.AngleAxis(MouseX, Vector3.up);

        Quaternion TargetRot = RotationX * RotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRot, Smooth * Time.fixedDeltaTime);
    }
}
