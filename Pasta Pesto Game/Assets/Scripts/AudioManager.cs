using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    public void Play(string pName)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == pName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + pName + " not found!");
            return;
        }
        if (s.Source.isPlaying)
            return;
        else
            s.Source.Play();
    }

    public void Stop(string pName)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == pName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + pName + " not found!");
            return;
        }

        s.Source.Stop();
    }
}
