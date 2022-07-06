using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    public float target;
    public float speed = 1;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if(start){Zoom();}
    }
    public void IsStarting(){
        start = true;
    }
    public void Zoom(){
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, target, speed);
    }
}
