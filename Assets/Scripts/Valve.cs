using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public float m_rotationSpeed = .1f;
    public AudioClip m_sound;

    private AudioSource m_audio;
    private float m_targetVolume = 0;
    private bool m_selected;
    private float m_rot;
    private Vector3 oldMousePos, currentPos, delta;

    void Start()
    {
        m_audio = gameObject.AddComponent<AudioSource>();
        m_audio.clip = m_sound;
        m_audio.loop = true;
        m_audio.Play();
    }

    void Update()
    {
        currentPos = Input.mousePosition;
        delta = currentPos - oldMousePos;

        if (m_selected)
        {
            m_targetVolume = m_rot != delta.x ? 1 : 0;
            m_rot = Mathf.Lerp(m_rot, delta.x, Time.deltaTime / m_rotationSpeed);
        }
        else
        {
            m_targetVolume = 0;
            m_rot = Mathf.Lerp(m_rot, 0, Time.deltaTime / m_rotationSpeed);
        }

        transform.Rotate(Vector3.up, m_rot, Space.Self);
        m_audio.volume = Mathf.Lerp(m_audio.volume, m_targetVolume, .1f);
        oldMousePos = currentPos;
    }

    public void Select()
    {
        m_selected = true;
    }

    public void Deselect()
    {
        m_selected = false;
    }

    public float GetRotation()
    {
        return m_rot;
    }
}
