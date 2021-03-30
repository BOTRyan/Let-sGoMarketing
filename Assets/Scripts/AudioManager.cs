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

        public bool musicMuted;
    public bool sfxMuted;

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

    private void Update()
    {
        if (musicMuted)
        {
            mixer.SetFloat("Theme-Exposed", -100);
        }
        else
        {
            mixer.SetFloat("Theme-Exposed", 10);
        }

        if (sfxMuted)
        {
            mixer.SetFloat("SFX-Exposed", -100);
        }
        else
        {
            mixer.SetFloat("SFX-Exposed", 10);
        }
        
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

    public void Stop(string name)
    {
        //to play sound, type "FindObjectOfType<AudioManager>().Play("SoundName");" in the file/section of code that would play sound

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
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
}
