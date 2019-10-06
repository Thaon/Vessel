using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousSound : MonoBehaviour
{
    public AudioClip m_sound;
    public bool m_isActive;

    private AudioSource m_source;

    void Start()
    {
        m_source = gameObject.AddComponent<AudioSource>();
        m_source.loop = true;
        m_source.clip = m_sound;
    }

    public void Play()
    {
        m_source.Play();
    }

    public void Stop()
    {
        m_source.Stop();
    }

    public void SwitchActivation(bool state)
    {
        m_isActive = state;
        if (!m_isActive)
            Stop();
    }
}
