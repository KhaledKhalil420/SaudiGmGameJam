using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceTheAudio : MonoBehaviour
{
    public GameObject NewAudioManager;
    void Start()
    {
        Destroy(GameObject.Find("AudioManager"));
        Instantiate(NewAudioManager);
    }
}
