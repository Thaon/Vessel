using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    public float m_adjustingSpeed = .1f;
    public AudioClip m_sound;
    public float m_targetValue;
    public bool m_goBackToDefaults = false;

    private AudioSource m_audio;
    private float m_targetVolume = 0;
    private bool m_selected;
    private float m_value, m_defaultValue;
    private Vector3 oldMousePos, currentPos, delta;
    private Animator m_anim;

    void Start()
    {
        m_audio = gameObject.AddComponent<AudioSource>();
        m_audio.clip = m_sound;
        m_audio.loop = true;
        m_audio.Play();
        m_anim = GetComponent<Animator>();
        m_value = m_targetValue;
        m_defaultValue = m_targetValue;
        m_anim.Play("Animation", 0, m_value); //set initial state
    }

    void Update()
    {
        currentPos = Input.mousePosition;
        delta = currentPos - oldMousePos;

        if (m_selected)
        {
            m_targetVolume = m_targetValue != m_value ? 1 : 0;

            m_targetValue += delta.y / 1000;
            m_targetValue = Mathf.Clamp01(m_targetValue);

            m_value = Mathf.Lerp(m_value, m_targetValue, Time.deltaTime / m_adjustingSpeed);
        }
        else
        {
            if (m_goBackToDefaults)
            {
                m_value = Mathf.Lerp(m_value, m_defaultValue, Time.deltaTime / m_adjustingSpeed);
                m_targetValue = m_value;
            }

            m_targetVolume = 0;
        }

        m_anim.Play("Animation", 0, m_value);
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

    public float GetValue()
    {
        return m_value;
    }
}
