using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] Sounds;

    public static AudioManager Instance;
    void Awake() 
    {
        
        DontDestroyOnLoad(gameObject);
         if (Instance == null)
            Instance = this;
        else
        {

            Destroy(gameObject);
            return;
        }

        foreach(Sound S in Sounds)
        {
            S.Source = gameObject.AddComponent<AudioSource>();
            S.Source.volume = S.Volume;
            S.Source.clip = S.Clip;
            S.Source.loop = S.Loop;
            S.Source.playOnAwake = S.PlayOnAwake;
        }
        foreach(Sound S in Sounds)
        {
            if(S.Source.playOnAwake == true)
            {
                S.Source.Play();
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
            return;
        s.Source.Play();
    }

    public void ChangeCertainSound(string name, float V)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
            return;
        s.Source.volume = V;
    }

    public void ChangeAllSounds(float V)
    {
        
        foreach(Sound S in Sounds)
        {
            S.Source.volume = V;
        }
    }
}
