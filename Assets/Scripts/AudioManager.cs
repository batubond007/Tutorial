using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<AudioClip> clips;
    public AudioSource source;

    public void PlayShootSound()
    {
        source.Stop();
        source.clip = clips[0];
        source.Play();
    }
    
    public void PlayZombieDeathSound()
    {
        source.Stop();
        source.clip = clips[1];
        source.Play();
    }
}
