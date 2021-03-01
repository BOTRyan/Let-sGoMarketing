using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

// ATTACHED TO AudioManager PREFAB. The prefab should be placed in the start screen and NOWHERE ELSE since there's a DontDestroyOnLoad()

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public AudioMixer mixer;

    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        //to play sound, type "FindObjectOfType<AudioManager>().Play("SoundName");" in the file/section of code that would play sound

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    IEnumerator playSoundWithDelay(string clip, float delay, Sound s)
    {
        yield return new WaitForSeconds(delay);

        //to play sound, type "FindObjectOfType<AudioManager>().PlayInSeconds("SoundName", float);" in the file/section of code that would play sound
        s.source.Play();
    }

    public void PlayInSeconds(string name, float seconds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        else
        {
            StartCoroutine(playSoundWithDelay(name, seconds, s));
        }
    }
    public void PlayUninterrupted(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        else s.source.PlayOneShot(s.source.clip, s.source.volume);
    }
    
    public void ChangeBGVolume(float vol)
    {
        mixer.SetFloat("Theme-Exposed", Mathf.Log10(vol) * 20);
    }

    public void ChangeSFXVolume(float vol)
    {
        mixer.SetFloat("SFX-Exposed", Mathf.Log10(vol) * 20);
    }
}
