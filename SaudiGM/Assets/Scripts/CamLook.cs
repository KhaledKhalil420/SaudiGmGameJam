using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{

    float MouseX, MouseY, Xrotation;
    public float Sen, Max, Min;
    public Transform Player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * Sen * 2 * Time.deltaTime;

        MouseY = Input.GetAxis("Mouse Y") * Sen * 2 * Time.deltaTime;

        Xrotation -= MouseY;

       Xrotation =  Mathf.Clamp(Xrotation, -90, 90);

        //apply the Rotation to the camera
        transform.localRotation = Quaternion.Euler(Xrotation, 0, transform.localRotation.z);
        //apply the Rotation to the Player 
        Player.Rotate(Vector3.up * MouseX);

    }
}
