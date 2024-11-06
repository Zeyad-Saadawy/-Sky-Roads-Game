using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public music[] musics;
    // Start is called before the first frame update
    void Start()
    {
        foreach(music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.soundClip;
            m.source.volume = m.volume;
            m.source.loop = m.loop;
        }
    }

    public void Play(string name)
    {
        foreach (music m in musics)
        {
            if (m.soundName == name)
            {
                m.source.Play();
            }
        }
    }
    public void Stop(string name)
    {
        foreach (music m in musics)
        {
            if (m.soundName == name)
            {
                m.source.Stop();
            }
        }
    }
}
