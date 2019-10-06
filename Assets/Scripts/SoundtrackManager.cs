using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public AudioClip[] m_sounds;
    [Range(0,1)]
    public float m_volume;

    private AudioSource m_source;
    private int m_currentlySelected;

    void Start()
    {
        m_source = gameObject.AddComponent<AudioSource>();
        m_currentlySelected = Random.Range(0, m_sounds.Length);
        m_source.PlayOneShot(m_sounds[m_currentlySelected], m_volume);
        StartCoroutine(PlayCO());
    }

    IEnumerator PlayCO()
    {
        yield return new WaitForSeconds(m_sounds[m_currentlySelected].length);
        m_currentlySelected = Random.Range(0, m_sounds.Length);
        m_source.PlayOneShot(m_sounds[m_currentlySelected], m_volume);
        StartCoroutine(PlayCO());
    }
}
