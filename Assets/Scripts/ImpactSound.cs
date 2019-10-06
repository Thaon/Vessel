using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioClip m_sound;

    private AudioSource m_source;

    void Start()
    {
        m_source = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_source.PlayOneShot(m_sound, 2);
    }

}
