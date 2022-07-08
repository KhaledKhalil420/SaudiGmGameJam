using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioClip drag;
    public AudioClip punch;
    public AudioClip click;
     
    public AudioSource source;

    public void Drag()
    {
        source.PlayOneShot(drag);
    }
    public void Punch()
    {
        source.PlayOneShot(punch);
    }
    public void Click()
    {
        source.PlayOneShot(click);
    }
}
