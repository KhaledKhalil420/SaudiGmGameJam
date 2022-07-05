using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip Clip;
    public bool Loop;
    public bool PlayOnAwake;
    [Range(0, 1)]
    public float Volume;

    [HideInInspector]
    public AudioSource Source;
}
