using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instanse;
    void Awake()
    {
        if (instanse == null)
            instanse = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.sourse = gameObject.AddComponent<AudioSource>();
            s.sourse.clip = s.clip;
            s.sourse.volume = s.volume;
            s.sourse.pitch = s.pitch;
            s.sourse.loop = s.loop;
            s.sourse.outputAudioMixerGroup = s.audioMix;
        }
       
    }
    void Start()
    {
        Play("MainTheme");
    }
    public void Play(string name)
    {
        //FindObjectOfType<AudioManager>().Play("Name");
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        s.sourse.Play();
        if(s==null)
        {
            Debug.LogWarning("Wrong name of the sound");
            return;
        }
            
    }
}
